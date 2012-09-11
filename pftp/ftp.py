import sys

import val
import getpass
#import ftp_thread
from ftplib import  FTP

def encodeutf(s, encoding):
    if isinstance(s, unicode):
        return s
    else:
        return unicode(s, encoding)

def printlist():
#	line = []
#	line = val.f.nlst()
#	for k in line:
#		print encodeutf(k,'gb2312')
	data = []
	val.f.dir(data.append)
	for k in data:
		print encodeutf(k,'gb2312')

#global f = ftp()
def printdir():
	try:
		printlist()
	except:
		print 'fail to get dir'

def cd(path):
	origin_path = val.path
	try:
		
		if path == '':
			val.path = '/'

		elif path[0] == "/":
			val.path = path
		else:
			val.path += path
		
#		print val.path
#		print path
		val.f.cwd(val.path)
	except:
		val.path = origin_path
		print 'error path'

def upload(file):
	try:
		val.f.storbinary("STOR " + file, open(file, "rb"),1024)
		print 'success to put'

	except:
		print 'fail to put'

def download(filename, outfile=None):
	try:
		if outfile is None:
			outfile = sys.stdout
		binaryfile = open(outfile,'wb')
		val.f.retrbinary("RETR " + filename, binaryfile.write)
		print 'success to get'
	except:
		print 'fail to get'


def get_cmd(string):
	p = string.find(' ')
	if not (p == -1):
		cmd = string[0:p] # cmd
		str = string[p+1:len(string)] # str
	else:
		cmd = string
		str = ''

	if cmd == 'open':
		val.f = FTP(str)
		val.ftpname = str
 		print val.f.getwelcome()
		print 'success connect to the server'
	if cmd == 'login':
		try:
			name = raw_input("username: ")
			pwd = getpass.getpass('password: ')
#			pwd  = raw_input("password: ")
			val.f.login(name,pwd)
			print 'success login in'
			val.name = name
			val.pwd = pwd
			val.path = '/'
		except:
			print 'fail to log in'
	if cmd == 'ls':
		printdir()
	if cmd == 'cd':
#		print str
		cd(str)
	if cmd == 'put':
		upload(str)
	if cmd == 'get':
		str_downfile = raw_input("local path = (e.g /home/sakura/)")
		str_downfile += str
		download(str, str_downfile)
	if cmd == 'start':
		x = string.find(' ', p + 1)
		if not (x == -1):
			cmd = string[p + 1:x] # cmd
			str = string[x + 1:len(string)] # str
		else:
			cmd = string
			str = ''
		#pro = producer = Producer('Producer',queue)
		th_ftp = ftp_thread.FTPthread('cmd',ftpname,str,cmd)
		th_ftp.start()
def main():
	print '---------------------------------------------'
	print '-----------------pftp v1.1-------------------'
	print '---------support utf-8 & gb2312--------------'
	print '--   usage: open login ls cd put get      ---'
	print '- open ftp_url e.g open public.sjtu.edu.cn  -'
	print '- login     ---------------------------------'
	print '- ls        ---------------------------------'
	print '- cd   cd /dir1/dir2   cd dir1      ---------'
	print '- put filename(local_currentdir)    ---------'
	print '- get filename(ftp_currentdir)      ---------'
	print '- coded by SakurA(&PopA)             --------'
	print '- contact: popacai@gmail.com  QICQ:447521915-'
	print '- enjoy it                          ---------'
	while (1):
	        cmd = raw_input("pftp> ")
		if cmd == 'bye':
			print 'GoodBye!'
			val.f.close()
			break;
		get_cmd(cmd)
	

main()
