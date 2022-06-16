# Setur Contact Manager

## Description

Store contact info and generate report based on location

## Getting Started

### Dependencies

* .Net Core 5
* PostgreSQL
* Kafka
* Docker
* Automapper

### Executing program

* Create Kafka topic
```
docker compose exec broker \
  kafka-topics --create \
    --topic purchases \
    --bootstrap-server localhost:9092 \
    --replication-factor 1 \
    --partitions 1
```
*Run docker compose
```
docker-compose  -f ./docker-compose.yml -f ./docker-compose.override.yml -d up
```


## Authors

Muhammed Balta
