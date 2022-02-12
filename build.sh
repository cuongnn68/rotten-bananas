#!/bin/bash
docker version
docker build \
    -t rottenbananas.azurecr.io/rating-service:release \
    -f ./src/RatingService/Dockerfile \
    ./src/RatingService/ \
&& docker build \
    -t rottenbananas.azurecr.io/movie-service:release \
    -f ./src/MovieService/Dockerfile \
    ./src/MovieService/ \
&& docker build \
    -t rottenbananas.azurecr.io/user-manager-service:release \
    -f ./src/UserManagerService/Dockerfile \
    ./src/UserManagerService/ \
&& docker build \
    -t rottenbananas.azurecr.io/webspa-envoy:release \
    -f ./src/BFF.WebSPA/envoy/Dockerfile \
    ./src/BFF.WebSPA/envoy/ \
&& echo " ==> builded containers"