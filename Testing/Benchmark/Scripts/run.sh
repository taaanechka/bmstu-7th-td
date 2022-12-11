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

