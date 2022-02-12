## Kubernetes

- [How to pull images from private registry](https://kubernetes.io/docs/tasks/configure-pod-container/pull-image-private-registry/)
- [How to get logs in k8s](https://kubernetes.io/docs/tasks/debug-application-cluster/_print/)

- Kafka quick test: 


``` 
// create topic: 
bin/kafka-topics.sh --create --partitions 1 --replication-factor 1 --topic quickstart-events --bootstrap-server kafka-broker0-service:9092 

// start producer:
bin/kafka-console-producer.sh --topic quickstart-events --bootstrap-server kafka-broker0-service:9092 

// start consumer: 
bin/kafka-console-consumer.sh --topic quickstart-events --from-beginning --bootstrap-server kafka-broker0-service:9092 
```