# CA variables
C=DK
O=RandomRavings
L=Copenhagen
CN=randomravings-ca

# Create CA
mkdir secrets
mkdir secrets/ca
eval "echo \"$(< ca_template.cnf)\"" > secrets/ca/ca.cnf
openssl req -new -nodes \
   -x509 \
   -days 365 \
   -newkey rsa:2048 \
   -keyout secrets/ca/ca.key \
   -out secrets/ca/ca.crt \
   -config secrets/ca/ca.cnf
cat secrets/ca/ca.crt secrets/ca/ca.key > secrets/ca/ca.pem


mkdir secrets/client-creds
keytool -keystore secrets/client-creds/kafka.client.truststore.pkcs12 \
    -alias CARoot \
    -import \
    -file secrets/ca/ca.crt \
    -storepass secret  \
    -noprompt \
    -storetype PKCS12

for i in $(seq -f "%02g" 1 3);
do
    BROKER="broker-${i}"
    CN=${BROKER}
    echo "------------------------------- ${BROKER} -------------------------------"

   mkdir secrets/${BROKER}-creds
   eval "echo \"$(< broker_template.cnf)\"" > secrets/${BROKER}-creds/${BROKER}.cnf

    # Create server key & certificate signing request(.csr file)
    openssl req -new \
    -newkey rsa:2048 \
    -keyout secrets/${BROKER}-creds/${BROKER}.key \
    -out secrets/${BROKER}-creds/${BROKER}.csr \
    -config secrets/${BROKER}-creds/${BROKER}.cnf \
    -nodes


    # Sign server certificate with CA
    openssl x509 -req \
    -days 3650 \
    -in secrets/${BROKER}-creds/${BROKER}.csr \
    -CA secrets/ca/ca.crt \
    -CAkey secrets/ca/ca.key \
    -CAcreateserial \
    -out secrets/${BROKER}-creds/${BROKER}.crt \
    -extfile secrets/${BROKER}-creds/${BROKER}.cnf \
    -extensions v3_req

    # Convert server certificate to pkcs12 format
    openssl pkcs12 -export \
    -in secrets/${BROKER}-creds/${BROKER}.crt \
    -inkey secrets/${BROKER}-creds/${BROKER}.key \
    -chain \
    -CAfile secrets/ca/ca.pem \
    -name secrets/${BROKER} \
    -out secrets/${BROKER}-creds/${BROKER}.p12 \
    -password pass:secret

    # Create server keystore
    keytool -importkeystore \
    -deststorepass secret \
    -destkeystore secrets/${BROKER}-creds/kafka.${BROKER}.keystore.pkcs12 \
    -srckeystore secrets/${BROKER}-creds/${BROKER}.p12 \
    -deststoretype PKCS12  \
    -srcstoretype PKCS12 \
    -noprompt \
    -srcstorepass secret

    # Save creds
    echo "secret" > secrets/${BROKER}-creds/${BROKER}_sslkey_creds
    echo "secret" > secrets/${BROKER}-creds/${BROKER}_keystore_creds

done