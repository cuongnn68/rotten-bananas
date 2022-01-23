## Kubernetes

Kafka script: 

``` bin/kafka-topics.sh --create --partitions 1 --replication-factor 1 --topic quickstart-events --bootstrap-server kafka-broker0-service:9092 ```

``` bin/kafka-console-producer.sh --topic quickstart-events --bootstrap-server kafka-broker0-service:9092 ```

``` bin/kafka-console-consumer.sh --topic quickstart-events --from-beginning --bootstrap-server kafka-broker0-service:9092 ```