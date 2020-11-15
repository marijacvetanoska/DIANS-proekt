#!/bin/bash

osmfilter map.osm --keep="tourism"="hotel" | osmconvert64.exe - --all-to-nodes --csv="@id @lon @lat name int_name" --csv-headline --csv-separator="," -o="hoteli.csv"
osmfilter map.osm --keep="tourism"="guest_house" | osmconvert64.exe - --all-to-nodes --csv="@id @lon @lat name int_name" --csv-headline --csv-separator="," -o="apartmani.csv"
osmfilter map2.osm --keep="tourism"="hotel" | osmconvert64.exe - --all-to-nodes --csv="@id @lon @lat name int_name" --csv-headline --csv-separator="," -o="hoteli2.csv"
osmfilter map2.osm --keep="tourism"="guest_house" | osmconvert64.exe - --all-to-nodes --csv="@id @lon @lat name int_name" --csv-headline --csv-separator="," -o="apartmani2.csv"
osmfilter map3.osm --keep="tourism"="hotel" | osmconvert64.exe - --all-to-nodes --csv="@id @lon @lat name int_name" --csv-headline --csv-separator="," -o="hoteli3.csv"
osmfilter map3.osm --keep="tourism"="guest_house" | osmconvert64.exe - --all-to-nodes --csv="@id @lon @lat name int_name" --csv-headline --csv-separator="," -o="apartmani3.csv"

$SHELL
