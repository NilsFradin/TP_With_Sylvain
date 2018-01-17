<?php

require "guzzle.phar";

$client = new Guzzle\Http\Client('http://localhost:8080/CloudTP1/webresources/');

$response = $client->get('generic/get')->send();

echo $response->getBody();
/*
$response = $client->post('generic/post/ChristCosmique')->send();

echo $response->getBody();

$response = $client->put('generic/put/ChristCosmique/Oriana')->send();

echo $response->getBody();

$response = $client->delete('generic/delete/Oriana')->send();

echo $response->getBody();*/
echo $response->getStatusCode();
?>
