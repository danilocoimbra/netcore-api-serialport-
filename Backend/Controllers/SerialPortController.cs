using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Core.Bus;
using Backend.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.IO.Ports;

namespace Backend.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SerialPortController : ApiController
    {

        public SerialPortController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator) : base(notifications, mediator) { }

        [HttpGet]
        public IActionResult GetPorts()
        {
            // Get a list of serial port names.
            string[] ports = SerialPort.GetPortNames();

            return Response(ports);
        }

        [HttpGet("{portName}/{baudRate}")]
        public IActionResult TestPort(string portName, int baudRate)
        {
            //this simply creates a SerialPort object then opens and closes the port
            SerialPort mySerialPort = new SerialPort(portName, baudRate);

            try
            {
                mySerialPort.Open();
                mySerialPort.Close();
            }
            catch (IOException ex)
            {
                NotifyError("Serialport error", ex.Message);

            }

            return Response();

        }

        [HttpGet("{portName}/{baudRate}")]
        public IActionResult ReadFromSerialPort(string portName, int baudRate)
        {
            var data = String.Empty;
            //this simply creates a SerialPort object then opens and closes the port
            SerialPort mySerialPort = new SerialPort(portName, baudRate);

            try
            {
                mySerialPort.Open();

                data = mySerialPort.ReadExisting();

                mySerialPort.Close();
            }
            catch (IOException ex)
            {
                NotifyError("Serialport error", ex.Message);

            }

            return Response(data);

        }

        [HttpPost("{portName}/{baudRate}/{message}")]
        public IActionResult WriteStringToSerialPort(string portName, int baudRate, string message)
        {
            var data = message;
            //this simply creates a SerialPort object then opens and closes the port
            SerialPort mySerialPort = new SerialPort(portName, baudRate);

            try
            {
                mySerialPort.Open();

                mySerialPort.WriteLine(data);

                mySerialPort.Close();
            }
            catch (IOException ex)
            {
                NotifyError("Serialport error", ex.Message);

            }

            return Response(data);

        }

    }
}