./kafka-cli write --topic test --bootstrap-server localhost:9092 --log-level warning << EOS
/sb
$(i=100; while [ $i -lt 120 ]; do echo "$(uuidgen),value$i"; i=$((i+1)); done)
/eb
EOS