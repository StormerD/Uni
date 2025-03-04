<?php
	session_start();
	if(!isset($_SESSION["counter"])) {
		$_SESSION["counter"] = 0;
	} else {
		$_SESSION["counter"] = $_SESSION["counter"] + 1;
	}
	echo "User ".$_SESSION["counter"].":<br />";
	echo randomString();
	
	function randomString($length = 10) {
    $chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    $randomString = "";
    for ($i = 0; $i < $length; $i++) {
        $randomString .= $chars[rand(0, strlen($chars) - 1)];
    }
    return $randomString;
}
?>