﻿using RCTool_Server.Client;
using RCTool_Server.Client.InboundPackets;
using RCTool_Server.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UIController.MainUI
{
    public class MainWindowLogic
    {
        public RcServer _ServerObj;

        public ICollection<RemoteClient> RemoteUserClients;

        public delegate void OnRemoteClientsUpdated(ICollection<RemoteClient> RemoteClients);
        public event OnRemoteClientsUpdated OnRemoteClientsUpdatedEvent;

        public ICommandExt ICmdStartServer
        {
            get { return _iCmdStartServer ?? (_iCmdStartServer = new ICommandExt(() => StartServer(), () => !_ServerObj?.IsStarted ?? true)); }
        }

        public ICommandExt ICmdStopServer
        {
            get { return _iCmdStopServer ?? (_iCmdStopServer = new ICommandExt(() => StopServer(), () => _ServerObj?.IsStarted ?? false)); }
        }

        private ICommandExt _iCmdStartServer;
        private ICommandExt _iCmdStopServer;
        private MainWindowManager mainWindowMgr;

        public MainWindowLogic(MainWindowManager mainWindowManager)
        {
            this.mainWindowMgr = mainWindowManager;
        }

        public void StartServer()
        {
            _ServerObj = new RcServer(IPAddress.Any, 9900);
            _ServerObj.InboundPacketHandler = new InboundPacketHandler(new ClientHandler(_ServerObj));
            _ServerObj.Start();
            RemoteUserClients = _ServerObj.InboundPacketHandler.ClientHandler.AuthenticatedClients.Values;

            _ServerObj.InboundPacketHandler.ClientHandler.ClientRegisteredEvent += remoteClient =>
            {
                UpdateServerListCol();
            };

            _ServerObj.InboundPacketHandler.ClientHandler.ClientDisconnectedEvent += remoteClient =>
            {
                UpdateServerListCol();
            };

            _ServerObj.InboundPacketHandler.ClientHandler.ClientPacketReceivedEvent += (remoteClient, packet) =>
            {
                if (packet is InboundPacket02DataResponse dr && dr.ReceivedClientFacts != null)
                {
                    UpdateServerListCol();
                }
            };

            ICmdStartServer.NotifyStateChange();
            ICmdStopServer.NotifyStateChange();
        }

        public void StopServer()
        {
            _ServerObj.Stop();
            ICmdStartServer.NotifyStateChange();
            ICmdStopServer.NotifyStateChange();
            mainWindowMgr.ClientWindowMgr.CloseAllWindows();

        }

        public void UpdateServerListCol()
        {
            RemoteUserClients = _ServerObj.InboundPacketHandler.ClientHandler.AuthenticatedClients.Values;
            OnRemoteClientsUpdatedEvent?.Invoke(RemoteUserClients);
        }
    }
}
