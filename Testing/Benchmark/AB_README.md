# Нагрузочное тестирование на GET запросах

Нагрузочное тестирование проводилось со следующими параметрами:
* n = 10000 - общее количество запросов;
* c = 100 - количество одновременно конкурирующих запросов.

## Carter

### Сериализация (Json)

Команда
```
ab -n 1000 -c 100 http://localhost/json
```

Результат
```
This is ApacheBench, Version 2.3 <$Revision: 1901567 $>
Copyright 1996 Adam Twiss, Zeus Technology Ltd, http://www.zeustech.net/
Licensed to The Apache Software Foundation, http://www.apache.org/

Benchmarking localhost (be patient)


Server Software:        Kestrel
Server Hostname:        localhost
Server Port:            80

Document Path:          /json
Document Length:        27 bytes

Concurrency Level:      100
Time taken for tests:   1.477 seconds
Complete requests:      1000
Failed requests:        0
Total transferred:      171000 bytes
HTML transferred:       27000 bytes
Requests per second:    677.21 [#/sec] (mean)
Time per request:       147.666 [ms] (mean)
Time per request:       1.477 [ms] (mean, across all concurrent requests)
Transfer rate:          113.09 [Kbytes/sec] received

Connection Times (ms)
              min  mean[+/-sd] median   max
Connect:        0    0   0.4      0       9
Processing:    40  126  59.0    111     292
Waiting:       24  123  59.8    108     290
Total:         40  126  59.0    111     292

Percentage of the requests served within a certain time (ms)
  50%    111
  66%    142
  75%    170
  80%    187
  90%    211
  95%    236
  98%    249
  99%    281
 100%    292 (longest request)
```

### PlainText

Команда
```
ab -n 1000 -c 100 http://localhost/plaintext
```

Результат
```
This is ApacheBench, Version 2.3 <$Revision: 1901567 $>
Copyright 1996 Adam Twiss, Zeus Technology Ltd, http://www.zeustech.net/
Licensed to The Apache Software Foundation, http://www.apache.org/

Benchmarking localhost (be patient)


Server Software:        
Server Hostname:        localhost
Server Port:            80

Document Path:          /plaintext
Document Length:        13 bytes

Concurrency Level:      100
Time taken for tests:   1.509 seconds
Complete requests:      1000
Failed requests:        0
Total transferred:      137259 bytes
HTML transferred:       11817 bytes
Requests per second:    662.48 [#/sec] (mean)
Time per request:       150.947 [ms] (mean)
Time per request:       1.509 [ms] (mean, across all concurrent requests)
Transfer rate:          88.80 [Kbytes/sec] received

Connection Times (ms)
              min  mean[+/-sd] median   max
Connect:        0    0   0.3      0       3
Processing:     1  118  67.1     92     276
Waiting:        0  115  65.6     91     275
Total:          1  118  67.1     92     276

Percentage of the requests served within a certain time (ms)
  50%     92
  66%    145
  75%    161
  80%    170
  90%    217
  95%    251
  98%    266
  99%    270
 100%    276 (longest request)
```

### Средние запросы

Команда
```
ab -n 1000 -c 100 http://localhost/middle
```

Результат
```
This is ApacheBench, Version 2.3 <$Revision: 1901567 $>
Copyright 1996 Adam Twiss, Zeus Technology Ltd, http://www.zeustech.net/
Licensed to The Apache Software Foundation, http://www.apache.org/

Benchmarking localhost (be patient)


Server Software:        Kestrel
Server Hostname:        localhost
Server Port:            80

Document Path:          /middle
Document Length:        1048572 bytes

Concurrency Level:      100
Time taken for tests:   17.105 seconds
Complete requests:      1000
Failed requests:        0
Total transferred:      1048715000 bytes
HTML transferred:       1048572000 bytes
Requests per second:    58.46 [#/sec] (mean)
Time per request:       1710.480 [ms] (mean)
Time per request:       17.105 [ms] (mean, across all concurrent requests)
Transfer rate:          59874.19 [Kbytes/sec] received

Connection Times (ms)
              min  mean[+/-sd] median   max
Connect:        0    0   0.5      1       9
Processing:   121 1658 397.7   1547    3398
Waiting:       71 1089 275.6   1048    2013
Total:        121 1658 397.7   1547    3399
ERROR: The median and mean for the initial connection time are more than twice the standard
       deviation apart. These results are NOT reliable.

Percentage of the requests served within a certain time (ms)
  50%   1547
  66%   1724
  75%   1856
  80%   1953
  90%   2195
  95%   2517
  98%   2733
  99%   2752
 100%   3399 (longest request)
```

### Тяжелые запросы

Команда
```
ab -n 10000 -c 100 -k http://localhost:5005/heavy
```

Результат
```
This is ApacheBench, Version 2.3 <$Revision: 1901567 $>
Copyright 1996 Adam Twiss, Zeus Technology Ltd, http://www.zeustech.net/
Licensed to The Apache Software Foundation, http://www.apache.org/

Benchmarking localhost (be patient)


Server Software:        Kestrel
Server Hostname:        localhost
Server Port:            80

Document Path:          /heavy
Document Length:        4194300 bytes

Concurrency Level:      100
Time taken for tests:   101.001 seconds
Complete requests:      1000
Failed requests:        0
Total transferred:      4194437877 bytes
HTML transferred:       4194294877 bytes
Requests per second:    9.90 [#/sec] (mean)
Time per request:       10100.075 [ms] (mean)
Time per request:       101.001 [ms] (mean, across all concurrent requests)
Transfer rate:          40555.45 [Kbytes/sec] received

Connection Times (ms)
              min  mean[+/-sd] median   max
Connect:        0    1   1.0      1      17
Processing:   219 9776 3219.4   8909   23778
Waiting:      145 7263 2916.4   6230   20688
Total:        220 9777 3219.4   8909   23778

Percentage of the requests served within a certain time (ms)
  50%   8909
  66%   9655
  75%  11347
  80%  12132
  90%  15328
  95%  15971
  98%  16850
  99%  20769
 100%  23778 (longest request)
```

## EmbedIO

### Сериализация (Json)

Команда
```
ab -n 1000 -c 100 http://localhost/api/json
```

Результат
```
This is ApacheBench, Version 2.3 <$Revision: 1901567 $>
Copyright 1996 Adam Twiss, Zeus Technology Ltd, http://www.zeustech.net/
Licensed to The Apache Software Foundation, http://www.apache.org/

Benchmarking localhost (be patient)


Server Software:        EmbedIO/3.5.2
Server Hostname:        localhost
Server Port:            80

Document Path:          /api/json
Document Length:        28 bytes

Concurrency Level:      100
Time taken for tests:   150.668 seconds
Complete requests:      1000
Failed requests:        0
Total transferred:      354000 bytes
HTML transferred:       28000 bytes
Requests per second:    6.64 [#/sec] (mean)
Time per request:       15066.845 [ms] (mean)
Time per request:       150.668 [ms] (mean, across all concurrent requests)
Transfer rate:          2.29 [Kbytes/sec] received

Connection Times (ms)
              min  mean[+/-sd] median   max
Connect:        0    0   0.7      0      12
Processing: 14982 15034  63.9  15010   15287
Waiting:        0   34  63.6     11     269
Total:      14982 15034  63.8  15011   15287

Percentage of the requests served within a certain time (ms)
  50%  15011
  66%  15019
  75%  15025
  80%  15031
  90%  15070
  95%  15250
  98%  15260
  99%  15266
 100%  15287 (longest request)
```

### PlainText

Команда
```
ab -n 1000 -c 100 http://localhost/api/plaintext
```

Результат
```
This is ApacheBench, Version 2.3 <$Revision: 1901567 $>
Copyright 1996 Adam Twiss, Zeus Technology Ltd, http://www.zeustech.net/
Licensed to The Apache Software Foundation, http://www.apache.org/

Benchmarking localhost (be patient)


Server Software:        EmbedIO/3.5.2
Server Hostname:        localhost
Server Port:            80

Document Path:          /api/plaintext
Document Length:        13 bytes

Concurrency Level:      100
Time taken for tests:   150.221 seconds
Complete requests:      1000
Failed requests:        0
Total transferred:      333000 bytes
HTML transferred:       13000 bytes
Requests per second:    6.66 [#/sec] (mean)
Time per request:       15022.145 [ms] (mean)
Time per request:       150.221 [ms] (mean, across all concurrent requests)
Transfer rate:          2.16 [Kbytes/sec] received

Connection Times (ms)
              min  mean[+/-sd] median   max
Connect:        0    0   0.6      0      10
Processing: 14985 15010  11.3  15008   15048
Waiting:        0   12   9.4      9      56
Total:      14985 15011  11.3  15008   15048

Percentage of the requests served within a certain time (ms)
  50%  15008
  66%  15011
  75%  15015
  80%  15018
  90%  15028
  95%  15035
  98%  15043
  99%  15043
 100%  15048 (longest request)
```

### Средние запросы

Команда
```
ab -n 1000 -c 100 http://localhost/api/middle
```

Результат
```
This is ApacheBench, Version 2.3 <$Revision: 1901567 $>
Copyright 1996 Adam Twiss, Zeus Technology Ltd, http://www.zeustech.net/
Licensed to The Apache Software Foundation, http://www.apache.org/

Benchmarking localhost (be patient)


Server Software:        EmbedIO/3.5.2
Server Hostname:        localhost
Server Port:            80

Document Path:          /api/middle
Document Length:        1048572 bytes

Concurrency Level:      100
Time taken for tests:   152.481 seconds
Complete requests:      1000
Failed requests:        0
Total transferred:      1048897000 bytes
HTML transferred:       1048572000 bytes
Requests per second:    6.56 [#/sec] (mean)
Time per request:       15248.104 [ms] (mean)
Time per request:       152.481 [ms] (mean, across all concurrent requests)
Transfer rate:          6717.64 [Kbytes/sec] received

Connection Times (ms)
              min  mean[+/-sd] median   max
Connect:        0    1   1.4      0      15
Processing: 15012 15145 245.6  15069   16332
Waiting:       17  147 243.2     69    1335
Total:      15012 15146 245.5  15070   16332

Percentage of the requests served within a certain time (ms)
  50%  15070
  66%  15087
  75%  15098
  80%  15114
  90%  15290
  95%  15809
  98%  16215
  99%  16241
 100%  16332 (longest request)
```

### Тяжелые запросы

Команда
```
ab -n 10000 -c 100 -k http://localhost:8080/api/heavy
```

Результат
```
This is ApacheBench, Version 2.3 <$Revision: 1901567 $>
Copyright 1996 Adam Twiss, Zeus Technology Ltd, http://www.zeustech.net/
Licensed to The Apache Software Foundation, http://www.apache.org/

Benchmarking localhost (be patient)


Server Software:        EmbedIO/3.5.2
Server Hostname:        localhost
Server Port:            80

Document Path:          /api/heavy
Document Length:        4194300 bytes

Concurrency Level:      100
Time taken for tests:   159.436 seconds
Complete requests:      1000
Failed requests:        0
Total transferred:      4194625000 bytes
HTML transferred:       4194300000 bytes
Requests per second:    6.27 [#/sec] (mean)
Time per request:       15943.557 [ms] (mean)
Time per request:       159.436 [ms] (mean, across all concurrent requests)
Transfer rate:          25692.60 [Kbytes/sec] received

Connection Times (ms)
              min  mean[+/-sd] median   max
Connect:        0    1   1.7      0      16
Processing: 15081 15578 956.8  15308   20676
Waiting:       93  575 946.0    306    5503
Total:      15082 15578 956.7  15308   20677

Percentage of the requests served within a certain time (ms)
  50%  15308
  66%  15378
  75%  15438
  80%  15467
  90%  15625
  95%  17934
  98%  19729
  99%  20216
 100%  20677 (longest request)
```