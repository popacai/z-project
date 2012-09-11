<?php
/* publish in GPLv3
 * by PopA
 * contact:
 *		mail: popacai@gmail.com
 *		qq: 447521915
 * enjoy!
 */

class Xiaonei
{
	var $cookie_jar;
	var $get_check;

	function login($username, $password) {
		$renren_username = $username;
		$renren_password = $password;
	
		$this->cookie_jar	= tempnam('./tmp','cookie');
		$ch = curl_init();
		curl_setopt($ch,CURLOPT_COOKIEJAR,$this->cookie_jar);
		curl_setopt($ch,CURLOPT_URL,"http://passport.renren.com/PLogin.do");
		curl_setopt($ch,CURLOPT_POST,TRUE);
		curl_setopt($ch,CURLOPT_FOLLOWLOCATION,TRUE);
		curl_setopt($ch,CURLOPT_POSTFIELDS,
			'email='.urlencode($renren_username).
			'&password='.urlencode($renren_password).
			'&autoLogin=true'.
			'&origURL=http%3A%2F%2Fwww.renren.com%2FHome.do&domain=renren.com');
		curl_setopt($ch,CURLOPT_RETURNTRANSFER,TRUE);
		$str = curl_exec($ch);
		$pattern = "/get_check:'([^']+)'/";
		preg_match($pattern,$str,$matches);
		$this->get_check = $matches[1];	
		curl_close($ch);
	}


	function changestate($item)
	{
		$ch1 = curl_init();
		curl_setopt($ch1,CURLOPT_URL,"http://status.renren.com/doing/update.do");
		curl_setopt($ch1,CURLOPT_COOKIEFILE,$this->cookie_jar);
		curl_setopt($ch1,CURLOPT_POST,TRUE);
		curl_setopt($ch1,CURLOPT_POSTFIELDS,'c='.urlencode($item).'&raw='.urlencode($item).'&isAtHome=1&publisher_form_ticket='.$this->get_check.'&requestToken='.$this->get_check);
		curl_setopt($ch1,CURLOPT_FOLLOWLOCATION,TRUE);
		curl_setopt($ch1,CURLOPT_REFERER,'http://status.renren.com/ajaxproxy.htm');
		curl_setopt($ch1,CURLOPT_RETURNTRANSFER,TRUE);
													 
		$ret = curl_exec($ch1);
		curl_close($ch1);
		$ret = json_decode($ret,TRUE);
		echo $ret['msg']."\n";
	}
	function leaveMsg($ID=0, $msg)
	{
		$ch1 = curl_init();
		curl_setopt($ch1,CURLOPT_URL,"http://gossip.renren.com/gossip.do");
		curl_setopt($ch1,CURLOPT_COOKIEFILE,$this->cookie_jar);
		curl_setopt($ch1,CURLOPT_POST,TRUE);
		curl_setopt($ch1,CURLOPT_POSTFIELDS,
			'body='.urlencode($msg).
			'&id='.urlencode($ID).
			'&cc='.urlencode($ID).
			'&cccc='.
			'&tsc='.
			'&profilever=2008'.
			'&headUrl='.
			'&lageUrl='.
			'&requestToken='.urlencode($this->get_check).
			'&only_to_me=0'.
			'&color='.
			'&ref=http://www.renren.com/profile.do'.
			'&mode=');
		curl_setopt($ch1,CURLOPT_FOLLOWLOCATION,TRUE);
		curl_setopt($ch1,CURLOPT_RETURNTRANSFER,TRUE);
													 
		$ret = curl_exec($ch1);
		curl_close($ch1);
		$ret = json_decode($ret,TRUE);
		echo $ret['visiter']."\n";
	}
	function send_msg()
	{
		$msg='
			';
	}
}

$xiaonei = new Xiaonei;
$xiaonei->login("popacai@gmail.com","(passwd)");
?>
