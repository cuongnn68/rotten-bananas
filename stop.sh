#!/bin/bash
kubectl version
kubectl delete deployment \
    movie-service-deployment \
    rating-service-deployment \
    user-manager-service-deployment \
    kafka-broker0-deployment \
    zookeeper-deployment \
    webspa-envoy-depl \