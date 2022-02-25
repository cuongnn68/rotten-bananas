#!/bin/bash
docker version \
&& echo " ===> build rating-service:release" \
&& docker build \
    -t rottenbananas.azurecr.io/rating-service:release \
    -f ./src/RatingService/Dockerfile \
    ./src/RatingService/ \
&& echo " ===> movie-service:release" \
&& docker build \
    -t rottenbananas.azurecr.io/movie-service:release \
    -f ./src/MovieService/Dockerfile \
    ./src/MovieService/ \
&& echo " ===> user-manager-service:release" \
&& docker build \
    -t rottenbananas.azurecr.io/user-manager-service:release \
    -f ./src/UserManagerService/Dockerfile \
    ./src/UserManagerService/ \
&& echo " ===> build api-gateway-envoy:release" \
&& docker build \
    -t rottenbananas.azurecr.io/api-gateway-envoy:release \
    -f ./src/ApiGateway/envoy/Dockerfile \
    ./src/ApiGateway/envoy/ \
&& echo " ===> build web-spa:release" \
&& docker build \
    -t rottenbananas.azurecr.io/web-spa:release \
    -f ./src/WebSPA/Dockerfile \
    ./src/WebSPA/ \
&& echo "" \
&& echo " ===> builded success" 