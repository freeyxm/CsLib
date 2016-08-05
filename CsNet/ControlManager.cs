﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace CsNet
{
    public class ControlManager
    {
        private SocketDispatcher m_dispatcher;
        private SocketMaster m_master;
        private Thread m_masterThread;

        private int m_workerNum;
        private List<SocketWorker> m_workers;
        private List<Thread> m_workerThreads;

        public ControlManager(int workerNum)
        {
            m_workerNum = workerNum;
            m_workers = new List<SocketWorker>(workerNum);
            m_workerThreads = new List<Thread>(workerNum);

            m_dispatcher = new SocketDispatcher(1000, 100);
            m_dispatcher.SetProducterTimeout(1000);
            m_dispatcher.SetConsumerTimeout(500);

            m_master = new SocketMaster(m_dispatcher, new SocketListener(1, 10000));
        }

        public void Start()
        {
            InitWorkers();
            StartWorkers();

            m_masterThread = new Thread(new ThreadStart(m_master.Run));
            m_masterThread.Start();
        }

        public void Stop()
        {
            m_master.Quit();
            for (int i = 0; i < m_workers.Count; ++i)
            {
                m_workers[i].Quit();
            }
        }

        public void Join()
        {
            m_masterThread.Join();
            for (int i = 0; i < m_workerThreads.Count; ++i)
            {
                m_workerThreads[i].Join();
            }
        }

        public SocketListener GetSocketListener()
        {
            return m_master.GetListener();
        }

        private void InitWorkers()
        {
            for (int i = 0; i < m_workerNum; ++i)
            {
                SocketWorker worker = new SocketWorker(m_dispatcher);
                m_workers.Add(worker);
                Thread thread = new Thread(new ThreadStart(worker.Run));
                m_workerThreads.Add(thread);
            }
        }

        private void StartWorkers()
        {
            for (int i = 0; i < m_workerThreads.Count; ++i)
            {
                m_workerThreads[i].Start();
            }
        }
    }
}
