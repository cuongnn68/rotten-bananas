#!/bin/bash
kubectl delete \
    deployment.apps/movie-service-deployment \
    deployment.apps/rating-service-deployment \
    deployment.apps/user-manager-service-deployment \
    deployment.apps/kafka-broker0-deployment \
    deployment.apps/zookeeper-deployment \
    deployment.apps/api-gateway-deployment \
    deployment.apps/web-spa-deployment \
    service/movie-service \
    service/rating-service \
    service/user-manager-service \
    service/web-spa-service \
    service/api-gateway-service \
    service/kafka-broker0-service \
    service/zookeeper-service \
    secret/general-secret \
