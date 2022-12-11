from flask import Flask
from flask import request
app = Flask(__name__)
ListOfMessages = list()

@app.route('/')
def hello_world():
	return "Flask Server is running! \
		<br><a href='/status'>Check status</a>"

@app.route('/status')
def status():
	return {
		'messages_count': len(ListOfMessages)
	}

@app.route('/api/Messanger', methods=["POST"])
def SendMessage():
	msg = request.json
	print(msg)
	ListOfMessages.append(msg)
	msg_text = f"{msg['UserName']} <{msg['TimeStamp']}>: {msg['MessageText']}"
	print(f"Всего сообщений: {len(ListOfMessages)} Посланное сообщение: {msg_text}")
	return f"Сообщение отослано успешно. Всего сообщений: {len(ListOfMessages)}", 200

@app.route('/api/Messanger/<int:id>')
def GetMessage(id: int):
	print(id)
	if id >= 0 and id < len(ListOfMessages):
		print(ListOfMessages[id])
		return ListOfMessages[id], 200
	else:
		return "Not Found", 400






if __name__ == "__main__":
	app.run()
