if ./build.sh
then
    docker push rottenbananas.azurecr.io/rating-service:release
    docker push rottenbananas.azurecr.io/movie-service:release
    docker push rottenbananas.azurecr.io/user-manager-service:release
    docker push rottenbananas.azurecr.io/api-gateway-envoy:release
    docker push rottenbananas.azurecr.io/web-spa:release
fi