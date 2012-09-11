#!/usr/bin/python
# -*- coding: utf-8 -*-
'''
	BY PopA
	此程序由python 2.6.5 以及 ubuntu 10.04LTS下调试通过
	参考了众多的代码。感谢前驱者无限的帮助
	版权所有，任何人可以修改，复制，传播，但必须注明原作者
	欢迎交流
	contact:
		QQ:447521915
		Email:popacai@gmail.com
'''
import urllib,urllib2,cookielib,re,time
import sys
def getTicket(html):
	a = html.find("get_check:'")
	a = a + 11
	b = html.find("'",a)
	string = html[a:b]	
	return string
class xiaonei():
	def __init__(self,email,password):
		self.url = 'http://www.renren.com/'
		self.email = email
		self.password = password
		self.cookie = cookielib.LWPCookieJar() 
		self.opener = urllib2.build_opener(urllib2.HTTPCookieProcessor(self.cookie))
		self.friendIdList = []
	
	def login(self):
		url = self.url+'PLogin.do/'
		params = urllib.urlencode({'email':self.email,'password':self.password})
		response = self.opener.open(urllib2.Request(url,params))
		url = self.url+'home'
		if response.geturl()==url:
			print 'Login Succesfully!'
			self.cookie.save('xiaonei.cookie')  
			self.ticket = ""
			response = self.opener.open('http://www.renren.com/home').read()
			self.ticket = getTicket(response)
			print self.ticket
		else:
			print 'Login Failed'
	def changeState(self,newStatus):
		ticket = self.ticket
		s = newStatus
		status = {"isAtHome":"1"}
		status['c'] = s
		status['raw'] = s
		status['publisher_form_ticket'] = ticket
		status['requestToken'] = ticket
		response = self.opener.open('http://status.renren.com/doing/update.do?',urllib.urlencode(status))
		print 'ok', response.read()
		
	def leaveMsg(self,ID,msg = 'hello'):
		ticket = self.ticket
		status = {"body":msg}
		status ['id'] = ID 
		status ['cc'] = ID
		status ['cccc='] = ''
		status ['tsc'] = ''
		status ['profilever'] = 2008
		status ['headUrl'] = ''
		status ['largeUrl'] = ''
		status ['requestToken'] = ticket
		status ['only_to_me'] = '0'
		status ['color'] = ''
		status ['ref'] = r'http://www.renren.com/profile.do'
		status ['mode'] = ''
		status ['requestToken'] = ticket
		response = self.opener.open('http://gossip.renren.com/gossip.do',urllib.urlencode(status)).read()
		if (response.find("visiter") != -1):
			print 'ok'
		else:
			print 'error, fail to sent'
	def getFriendList(self):
		url = 'http://friend.renren.com/myfriendlistx.do'
		response = self.opener.open(urllib2.Request(url))
		html = response.read()
		friend = str(re.search('friends=/[{.*}/]',html).group())
		friendId = re.findall('"id":/d+',friend)
		for id in friendId:
			self.friendIdList.append(id.lstrip('"id":'))
			
	def browseFriend(self):
		cnt=0
		for friendId in self.friendIdList:
			cnt+=1
			url='http://www.renren.com/profile.do?id='+'%s'%(friendId)
			response = self.opener.open(urllib2.Request(url))
			html = response.read()
#			f = open("1.html","w")
#			f.write(html)
			x = html.find('<title>')
			y = html.find('</title>')
			x += 26
			s = html[x:y]
			print "%d/%d %s" % (cnt,len(self.friendIdList),s)
	def sayHello(self, word):
		cnt = 0
		for friendId in self.friendIdList:
			cnt += 1
			self.leaveMsg(friendId,word)
			print "%d/%d %s" % (cnt,len(self.friendIdList),friendId)
			
def main():
	if len(sys.argv) < 2:
		print 'usage: email@xxx.com passwd'
		exit()	
	app = xiaonei(sys.argv[1],sys.argv[2])
	app.login()
	app.getFriendList()
	
	app.changeState('hello!')
#leavemsg

	Id = ''
	string = 'UTF-8数据'
	i = 0
	while (i < len(string)):
		if string[i] > '~':
			tstr = string[i:i+3]
			print tstr
			app.leaveMsg(Id,tstr)
			i+=3
		else:
			tstr = string[i]
			print tstr
			app.leaveMsg(Id,tstr)
			i+=1
		time.sleep(5)	

	app.browseFriend() #100名后需要验证码=.=
main()