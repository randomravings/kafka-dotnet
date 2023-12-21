# CA variables
C=DK
O=RandomRavings
L=Copenhagen
CN=randomravings-ca

# Create CA
mkdir ca
eval "echo \"$(< ca_template.cnf)\"" > ca/ca.cnf
openssl req -new -nodes \
   -x509 \
   -days 365 \
   -newkey rsa:2048 \
   -keyout ca/ca.key \
   -out ca/ca.crt \
   -config ca/ca.cnf
cat ca/ca.crt ca/ca.key > ca/ca.pem

for i in $(seq -f "%02g" 1 3);
do
    BROKER="broker-${i}"
    CN = ${BROKER}
    echo "------------------------------- ${BROKER} -------------------------------"

   mkdir ${BROKER}-creds
   eval "echo \"$(< broker_template.cnf)\"" > ${BROKER}-creds/${BROKER}.cnf

    # Create server key & certificate signing request(.csr file)
    openssl req -new \
    -newkey rsa:2048 \
    -keyout ${BROKER}-creds/${BROKER}.key \
    -out ${BROKER}-creds/${BROKER}.csr \
    -config ${BROKER}-creds/${BROKER}.cnf \
    -nodes


    # Sign server certificate with CA
    openssl x509 -req \
    -days 3650 \
    -in ${BROKER}-creds/${BROKER}.csr \
    -CA ca/ca.crt \
    -CAkey ca/ca.key \
    -CAcreateserial \
    -out ${BROKER}-creds/${BROKER}.crt \
    -extfile ${BROKER}-creds/${BROKER}.cnf \
    -extensions v3_req

    # Convert server certificate to pkcs12 format
    openssl pkcs12 -export \
    -in ${BROKER}-creds/${BROKER}.crt \
    -inkey ${BROKER}-creds/${BROKER}.key \
    -chain \
    -CAfile ca/ca.pem \
    -name ${BROKER} \
    -out ${BROKER}-creds/${BROKER}.p12 \
    -password pass:secret

    # Create server keystore
    keytool -importkeystore \
    -deststorepass confluent \
    -destkeystore ${BROKER}-creds/kafka.${BROKER}.keystore.pkcs12 \
    -srckeystore ${BROKER}-creds/${BROKER}.p12 \
    -deststoretype PKCS12  \
    -srcstoretype PKCS12 \
    -noprompt \
    -srcstorepass secret

    # Save creds
    echo "secret" > ${BROKER}-creds/${BROKER}_sslkey_creds
    echo "secret" > ${BROKER}-creds/${BROKER}_keystore_creds

done