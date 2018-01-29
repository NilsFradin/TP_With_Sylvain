<?php

require "guzzle.phar";
try {
	$client = new \Guzzle\Http\Client();

	$response = $client->get("http://localhost:8080/CloudTP1/webresources/generic", array())->send();

	echo $response->getBody();
	/*
	$response = $client->post('post/ChristCosmique')->send();

	echo $response->getBody();

	$response = $client->put('put/ChristCosmique/Oriana')->send();

	echo $response->getBody();

	$response = $client->delete('delete/Oriana')->send();

	echo $response->getBody();
	*/
	echo $response->getStatusCode();

} catch(Exception $e) {
	echo $e->getMessage()."\n";
}
?>
