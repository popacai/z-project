import sys
import threading

import val
#import ftp_thread
from ftplib import  FTP

#global f = ftp()

class ThFTP(threading.Thread):
	def __init__(self, threadname, ftpname, name, pwd, s_cmd):
		threading.Thread.__init__(self, name = threadname)
#		self.sharedata = queue
#		self.f = FTP(str)
		self.f = FTP(ftpname)
#		self.f.login(name,pwd)
		self.f.login(name,pwd)
		self.s_cmd = s_cmd

	def printdir():
		try:
			print self.f.dir()
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
			self.f.cwd(val.path)
		except:
			val.path = origin_path
			print 'error path'

	def upload(file):
		try:
			self.f.storbinary("STOR " + file, open(file, "rb"),1024)
			print 'success to put'

		except:
			print 'fail to put'

	def download(filename, outfile=None):
		try:
			if outfile is None:
				outfile = sys.stdout
			binaryfile = open(outfile,'wb')
			self.f.retrbinary("RETR " + filename, binaryfile.write)
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
			self.f = FTP(str)
			#self.ftpname = str
			print 'success connect to the server'
		if cmd == 'login':
			try:
				name = raw_input("username: ")
				pwd  = raw_input("password: ")
				self.f.login(name,pwd)
				print 'success login in'
				val.name = name
				val.pwd = pwd
				print self.f.getwelcome()
				val.path = '/'
			except:
				print 'fail to log in'
		if cmd == 'ls':
			printdir()
		if cmd == 'cd':
			cd(str)
		if cmd == 'put':
			upload(str)
		if cmd == 'get':
			str_downfile = raw_input("local path = (e.g /home/sakura/)")
			str_downfile += str
			download(str, str_downfile)

	def run(self):
		get_cmd(self.s_cmd)
	

