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
		$renren_username=$username;
		$renren_password=$password;
	
		$this->cookie_jar	= tempnam('./tmp','cookie');
		$ch = curl_init();
		curl_setopt($ch,CURLOPT_COOKIEJAR,$this->cookie_jar);
		curl_setopt($ch,CURLOPT_URL,"http://3g.renren.com/login.do");
		curl_setopt($ch,CURLOPT_POST,TRUE);
		curl_setopt($ch,CURLOPT_FOLLOWLOCATION,TRUE);
		curl_setopt($ch,CURLOPT_POSTFIELDS,
			'email='.urlencode($renren_username).
			'&password='.urlencode($renren_password).
			'&autoLogin=true'.
			'&login='.urlencode('登录'));
		curl_setopt($ch,CURLOPT_RETURNTRANSFER,TRUE);
		$str = curl_exec($ch);
		curl_close($ch);
	}


	function changestate($item)
	{
		$ch1 = curl_init();
		curl_setopt($ch1,CURLOPT_URL,"http://3g.renren.com/status/wUpdateStatus.do");
		curl_setopt($ch1,CURLOPT_COOKIEFILE,$this->cookie_jar);
		curl_setopt($ch1,CURLOPT_POST,TRUE);
		curl_setopt($ch1,CURLOPT_POSTFIELDS,
			"sour=home".
			"&status=".$item.
			"&update=".urlencode('发布')
			);
		curl_setopt($ch1,CURLOPT_FOLLOWLOCATION,TRUE);
		curl_setopt($ch1,CURLOPT_REFERER,'http://3g.renren.com');
		curl_setopt($ch1,CURLOPT_RETURNTRANSFER,TRUE);
													 
		$ret = curl_exec($ch1);
		curl_close($ch1);
	}
	function sendmsg($ID,$sid,$title,$body)
	{
		$ch1 = curl_init();
		curl_setopt($ch1,CURLOPT_URL,
			"http://3g.renren.com/sendmessage.do".
			"?reciverid=".$ID.
			"&".$sid
		);
		curl_setopt($ch1,CURLOPT_COOKIEFILE,$this->cookie_jar);
		curl_setopt($ch1,CURLOPT_POST,TRUE);
		curl_setopt($ch1,CURLOPT_POSTFIELDS,
			"subject=".$title.
			"&message=".$body.
			"&post=".urlencode('发送').
			"&mesfrom=mesother"
			);
		curl_setopt($ch1,CURLOPT_FOLLOWLOCATION,TRUE);
		curl_setopt($ch1,CURLOPT_REFERER,'http://3g.renren.com');
		curl_setopt($ch1,CURLOPT_RETURNTRANSFER,TRUE);
													 
		$ret = curl_exec($ch1);
		echo $ret;
		curl_close($ch1);
	}
}
$xiaonei = new Xiaonei;
$xiaonei->login("popacai@gmail.com","(passwd here!)");
$xiaonei->changestate("your state");
$xiaonei->sendmsg('userid','AdOLHy2esuxNg17u1AAtIp&ega6nt',"newone","msg");
$xiaonei->leaveMsg("userid","your msg");
?>
