#!/bin/bash

echo "Start Carter container in docker."
docker-compose -f dockerCarter/docker-compose.yml up -d
echo

echo "Carter Benchmark has started!"
echo

echo "ab -n 1000 -c 100 http://localhost/json"
ab -n 1000 -c 100 http://localhost/json > "report/carter_json.csv"
echo

echo "ab -n 1000 -c 100 http://localhost/plaintext"
ab -n 1000 -c 100 http://localhost/plaintext > "report/carter_plaintext.csv"
echo

echo "ab -n 1000 -c 100 http://localhost/middle"
ab -n 1000 -c 100 http://localhost/middle > "report/carter_middle.csv"
echo

echo "ab -n 1000 -c 100 http://localhost/heavy"
ab -n 1000 -c 100 http://localhost/heavy > "report/carter_heavy.csv"
echo

echo "Carter Benchmark has finished!"
echo

echo "Stop Carter container in docker."
docker-compose -f dockerCarter/docker-compose.yml down
echo

echo "Start EmbedIO container in docker."
docker-compose -f dockerEmbedIO/docker-compose.yml up -d
echo

echo "EmbedIO Benchmark has started!"
echo

echo "ab -n 1000 -c 100 http://localhost/api/json"
ab -n 1000 -c 100 http://localhost/api/json > "report/embedio_json.csv"
echo

echo "ab -n 1000 -c 100 http://localhost/api/plaintext"
ab -n 1000 -c 100 http://localhost/api/plaintext > "report/embedio_plaintext.csv"
echo

echo "ab -n 1000 -c 100 http://localhost/api/middle"
ab -n 1000 -c 100 http://localhost/api/middle > "report/embedio_middle.csv"
echo

echo "ab -n 1000 -c 100 http://localhost/api/heavy"
ab -n 1000 -c 100 http://localhost/api/heavy > "report/embedio_heavy.csv"
echo

echo "EmbedIO Benchmark has finished!"
echo

echo "Stop EmbedIO container in docker."
docker-compose -f dockerEmbedIO/docker-compose.yml down
echo
