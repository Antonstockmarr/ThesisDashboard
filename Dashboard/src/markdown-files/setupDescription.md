# Setup Monitoring Solution 
1. Add <b>docker-compose.yml</b> file to root folder with other <b>docker-compose.yml</b> files
2. Find setup steps for monitoring tool below


### ELK servers
1. Put folder "elk" into root folder
2. ELK uses one port for <u>LogStash</u>, which is <b>8080</b> per default. Change it in <b>docker-compose.yml</b>  if necessary.
3. ELK uses one port for <u>ElasticSearch</u>, which is <b>9200</b> per default. Change it in "docker-compose.yml", "elk/logstash/config/logstash.yml" and "elk/kibana/config/kibana.yml" if necessary
4. ELK uses one port for <u>Kibana</u>, which is 5601 per default. Change it in "docker-compose.yml" if necessary


### Prometheus Server 
1. Put folder "prometheus" into root folder
3. Prometheus uses port 9090 per default. Change it in “docker-compose.yml” if necessary 
4. Go to prometheus/config/targets.json and add all hosts and ports you want to get healthchecks for.


### Jaeger Server 
1. Put folder "jaeger" into root folder
2. Jaeger uses port 16686 per default. Change it in “docker-compose.yml” if necessary
    

### Run Monitoring Servers
1. After completion of the steps for the desired monitoring tools - go to root folder and run
  $ docker-compose up


## Healthchecks
1. Go to the monitoring display port and search for "UP". This metric is 0 if the target is down, 1 if it is up.


## Error Logging
1. Add instrumentation to the application to send logs to the Logstash port. Log fields are put in the payload. There are many ways to do this. In c# one can use SeriLogger.
2. Go to the port used for Kibana after the setup is complete. Select an index for elastic search (fx "logstash-*").
3. Kibana will display logs and provide search handles.

## Distributed Tracing
1. Access https://opentelemetry.io/docs/instrumentation/ and install the necessary packages that matches the programming framework of the application
1.1 Instrument application as shown in documentation https://opentelemetry.io/docs/instrumentation/ 
2. Go to the UI port click on the service dropdown to identify request made by service and service dependencies.