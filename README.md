# SMSTwilio

**SMSTwilio** é uma solução desenvolvida em **.NET Core** que integra a API do Twilio para envio automatizado de mensagens SMS, coleta de respostas e gerenciamento de logs detalhados. O projeto suporta contas **Twilio Trial (gratuitas)**, permitindo o envio de mensagens SMS para números de telefone verificados.

---

## Descrição do Projeto (Português)

**SMSTwilio** é uma solução desenvolvida em **.NET Core** para o envio automatizado de mensagens SMS usando a API do Twilio. O projeto permite a integração com a API Twilio para enviar mensagens SMS, coletar respostas de destinatários e gerenciar logs detalhados de envios, erros e respostas. Ideal para sistemas que precisam de automação no envio de notificações via SMS.

### Funcionalidades Principais:
- **Envio de SMS**: Envia mensagens SMS automaticamente para números configurados.
- **Coleta de Respostas**: Recupera e registra respostas de SMS recebidas pelos números Twilio.
- **Geração de Logs**: Gera logs detalhados para envios bem-sucedidos, erros e respostas, organizados por data, hora e número de telefone.
- **Agendamento de Envio**: Configuração de horários de início e fim para envio de SMS, garantindo que as mensagens sejam enviadas dentro do período permitido.
- **Reenvio em Caso de Erros**: Implementação de reenvios automáticos em caso de falha no envio.
- **Testes Unitários**: Inclui um conjunto completo de testes unitários para garantir a estabilidade e qualidade do sistema.

---

## Descripción del Proyecto (Español)

**SMSTwilio** es una solución desarrollada en **.NET Core** para el envío automatizado de mensajes SMS utilizando la API de Twilio. El proyecto permite la integración con la API de Twilio para enviar mensajes SMS, recoger respuestas de los destinatarios y gestionar registros detallados de envíos, errores y respuestas. Ideal para sistemas que necesitan automatización en el envío de notificaciones vía SMS.

### Principales Funcionalidades:
- **Envío de SMS**: Envía mensajes SMS automáticamente a los números configurados.
- **Recuperación de Respuestas**: Recupera y registra las respuestas de SMS recibidas en los números Twilio.
- **Generación de Registros**: Genera registros detallados de los envíos exitosos, errores y respuestas, organizados por fecha, hora y número de teléfono.
- **Programación de Envío**: Configuración de horarios de inicio y fin para garantizar que los SMS se envíen dentro del periodo permitido.
- **Reenvío en Caso de Errores**: Implementación de reenvíos automáticos en caso de fallos en el envío.
- **Pruebas Unitarias**: Incluye un conjunto completo de pruebas unitarias para garantizar la estabilidad y calidad del sistema.

---

## Project Description (English)

**SMSTwilio** is a solution developed in **.NET Core** for automated SMS messaging using the Twilio API. The project allows integration with the Twilio API to send SMS messages, collect recipient responses, and manage detailed logs of sent messages, errors, and responses. It's ideal for systems that need automated notification delivery via SMS.

### Key Features:
- **SMS Sending**: Automatically sends SMS messages to configured numbers.
- **Response Collection**: Retrieves and logs SMS responses received by Twilio numbers.
- **Log Generation**: Generates detailed logs of successful deliveries, errors, and responses, organized by date, time, and phone number.
- **Scheduled Messaging**: Configures start and end times to ensure SMS are sent within the allowed time window.
- **Retry on Errors**: Implements automatic retries in case of message sending failures.
- **Unit Testing**: Includes a complete suite of unit tests to ensure system stability and quality.

---

## Como Criar uma Conta Gratuita no Twilio e Cadastrar Números de Telefone (Português)

### 1. Criando uma Conta Twilio Gratuita

1. Acesse [twilio.com](https://www.twilio.com/try-twilio) e clique em **"Sign Up"** para criar uma conta gratuita.
2. Preencha suas informações e confirme seu e-mail.
3. Verifique seu número de telefone durante o cadastro.
4. Acesse o **Twilio Console** para obter seu **Account SID** e **Auth Token**.

### 2. Verificando Números de Telefone

1. Acesse a seção **Phone Numbers** no console ou [aqui](https://www.twilio.com/console/phone-numbers/verified).
2. Adicione e verifique os números de telefone para envio.
3. Verifique o número por SMS ou chamada para permitir o envio de mensagens.

---

## Cómo Crear una Cuenta Gratuita en Twilio y Registrar Números de Teléfono (Español)

### 1. Creación de una Cuenta Gratuita en Twilio

1. Visita [twilio.com](https://www.twilio.com/try-twilio) y haz clic en **"Sign Up"** para crear una cuenta gratuita.
2. Completa tu información y confirma tu correo electrónico.
3. Verifica tu número de teléfono durante el registro.
4. Accede al **Twilio Console** para obtener tu **Account SID** y **Auth Token**.

### 2. Verificación de Números de Teléfono

1. Accede a la sección **Phone Numbers** en la consola o [aquí](https://www.twilio.com/console/phone-numbers/verified).
2. Añade y verifica los números de teléfono para enviar mensajes.
3. Verifica el número a través de SMS o llamada para permitir el envío de mensajes.

---

## How to Create a Free Twilio Account and Register Phone Numbers (English)

### 1. Creating a Free Twilio Account

1. Visit [twilio.com](https://www.twilio.com/try-twilio) and click **"Sign Up"** to create a free account.
2. Fill in your details and confirm your email.
3. Verify your phone number during the sign-up process.
4. Access the **Twilio Console** to get your **Account SID** and **Auth Token**.

### 2. Verifying Phone Numbers

1. Access the **Phone Numbers** section in the console or [here](https://www.twilio.com/console/phone-numbers/verified).
2. Add and verify phone numbers to send messages.
3. Verify the number via SMS or call to enable message sending.

---
---
---

## Descrição das Funções e Uso da Biblioteca (Português)

### 1. Envio de SMS (Função `SendSMS`)
```csharp
public void SendSMS(SMSMessage message)
```
- **Descrição**: Envia uma mensagem SMS para o número de telefone especificado.
- **Parâmetro**: `SMSMessage message` – Um objeto que contém o número de telefone de destino e o texto da mensagem.
- **Funcionamento**: Usa a API do Twilio para enviar a mensagem e registra o sucesso ou erro nos logs.

### 2. Coleta de Respostas (Função `CollectReceivedMessages`)
```csharp
public void CollectReceivedMessages()
```
- **Descrição**: Coleta as mensagens de resposta enviadas pelos destinatários para o número Twilio.
- **Funcionamento**: Faz uma chamada à API do Twilio para buscar as mensagens recebidas e registra as respostas nos logs.

### 3. Geração de Logs Detalhados (Função `FileLogger`)
A biblioteca oferece uma classe de logger personalizada que gera logs detalhados para três tipos de eventos: **envios de SMS**, **erros**, e **respostas recebidas**. Os logs são organizados por data, hora e número de telefone, facilitando o acompanhamento.

---

## Descripción de Funciones y Uso de la Biblioteca (Español)

### 1. Envío de SMS (Función `SendSMS`)
```csharp
public void SendSMS(SMSMessage message)
```
- **Descripción**: Envía un mensaje SMS al número de teléfono especificado.
- **Parámetro**: `SMSMessage message` – Un objeto que contiene el número de teléfono de destino y el texto del mensaje.
- **Funcionamiento**: Utiliza la API de Twilio para enviar el mensaje y registrar el éxito o error en los registros.

### 2. Recogida de Respuestas (Función `CollectReceivedMessages`)
```csharp
public void CollectReceivedMessages()
```
- **Descripción**: Recoge los mensajes de respuesta enviados por los destinatarios al número de Twilio.
- **Funcionamiento**: Realiza una llamada a la API de Twilio para buscar los mensajes recibidos y registra las respuestas en los registros.

### 3. Generación de Registros Detallados (Función `FileLogger`)
La biblioteca ofrece una clase personalizada de logger que genera registros detallados para tres tipos de eventos: **envío de SMS**, **errores** y **respuestas recibidas**. Los registros están organizados por fecha, hora y número de teléfono, lo que facilita el seguimiento.

---

## Description of Functions and Library Usage (English)

### 1. SMS Sending (Function `SendSMS`)
```csharp
public void SendSMS(SMSMessage message)
```
- **Description**: Sends an SMS message to the specified phone number.
- **Parameter**: `SMSMessage message` – An object that contains the recipient's phone number and the message text.
- **Functionality**: Uses the Twilio API to send the message and logs success or failure.

### 2. Response Collection (Function `CollectReceivedMessages`)
```csharp
public void CollectReceivedMessages()
```
- **Description**: Collects response messages sent by recipients to the Twilio number.
- **Functionality**: Calls the Twilio API to fetch received messages and logs the responses.

### 3. Detailed Log Generation (Function `FileLogger`)
The library offers a custom logger class that generates detailed logs for three event types: **SMS sent**, **errors**, and **received responses**. Logs are organized by date, time, and phone number for easy tracking.

---
---


