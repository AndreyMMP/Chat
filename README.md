#PORTUGUÊS<br/>
Essa é uma aplicação de chat em tempo real utilizando Websockets como middleware, jQuery como cliente do Websocket e manipulação do DOM do HTML.
<br/>Para controlar os acessos ao serviço foi utilizado o banco em memória Redis, armazenando em tempo real a entrada e a saída de usuários do chat.
<br/>Para os testes unitários as ferramentar utilizadas foram xUnit e MOQ.
<br/><br/>
Funcionalidades:<br/>
O usuário pode escolher um nickname e entrar na sala de chat.<br/>
O usuário pode ver quem está conectado na sala de chat.<br/>
O usuário pode enviar mensagens publicamente direcionado a todos que estão na sala.<br/>
O usuário pode enviar mensagens publicamente direcionado para um outro usuário especifico.<br/>
O usuário pode sair de sala de chat.<br/>
<br/>
Instruções para execução do projeto:<br/>
<b>1º</b> Redis instalado na maquina com servidor executando na porta 6379; OU Redis sendo executando instancia em Docker na porta 6379<br/>
Comandos docker para Redis:<br/>
docker pull redis<br/>
docker run -d -p 6379:6379 -i -t redis<br/>
<b>2º</b> Executar projeto Chat.Application
<br/><br/>
#ENGLISH<br/>
This is a real-time chat application using Websockets as middleware, jQuery as a Websocket client and HTML DOM manipulation.
<br/>To control access to the service, the Redis memory bank was used, storing the entrance and exit of chat users in real time.
<br/>For unit tests the tools used were xUnit and MOQ.
<br/><br/>
Functionalities:<br/>
The user can choose a nickname and enter the chat room.<br/>
The user can see who is connected in the chat room.<br/>
The user can send publicly targeted messages to everyone in the room.<br/>
The user can send messages publicly directed to another specific user.<br/>
The user can leave the chat room.<br/>
<br/>
Project execution instructions:<br/>
<b>1st</b> Redis installed on the machine with a server running on port 6379; OR Redis running instance in Docker on port 6379<br/>
Docker commands for Redis:<br/>
docker pull redis<br/>
docker run -d -p 6379:6379 -i -t redis <br/>
<b>2nd</b> Run Chat.Application project
