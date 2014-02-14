﻿using WampSharp.Core.Contracts;
using WampSharp.Core.Message;
using WampSharp.V2.Core.Contracts;
using WampSharp.V2.PubSub;
using WampSharp.V2.Rpc;

namespace WampSharp.V2
{
    public class WampServer<TMessage> : IWampServer<TMessage>, IWampMissingMethodContract<TMessage, IWampClient>
        where TMessage : class
    {
        private readonly IWampSessionServer<TMessage> mSession;
        private readonly IWampRpcServer<TMessage> mDealer;
        private readonly IWampPubSubServer<TMessage> mBroker;

        public WampServer(IWampSessionServer<TMessage> session,
                          IWampRpcServer<TMessage> dealer,
                          IWampPubSubServer<TMessage> broker)
        {
            mSession = session;
            mDealer = dealer;
            mBroker = broker;
        }

        public void Publish(IWampPublisher publisher, long requestId, TMessage options, string topic)
        {
            mBroker.Publish(publisher, requestId, options, topic);
        }

        public void Publish(IWampPublisher publisher, long requestId, TMessage options, string topic, TMessage[] arguments)
        {
            mBroker.Publish(publisher, requestId, options, topic, arguments);
        }

        public void Publish(IWampPublisher publisher, long requestId, TMessage options, string topic, TMessage[] arguments,
                            TMessage argumentKeywords)
        {
            mBroker.Publish(publisher, requestId, options, topic, arguments, argumentKeywords);
        }

        public void Subscribe(IWampSubscriber subscriber, long requestId, TMessage options, string topicUri)
        {
            mBroker.Subscribe(subscriber, requestId, options, topicUri);
        }

        public void Unsubscribe(IWampSubscriber subscriber, long requestId, long subscriptionId)
        {
            mBroker.Unsubscribe(subscriber, requestId, subscriptionId);
        }

        public void Register(IWampCallee callee, long requestId, TMessage options, string procedure)
        {
            mDealer.Register(callee, requestId, options, procedure);
        }

        public void Unregister(IWampCallee callee, long requestId, long registrationId)
        {
            mDealer.Unregister(callee, requestId, registrationId);
        }

        public void Call(IWampCaller caller, long requestId, TMessage options, string procedure)
        {
            mDealer.Call(caller, requestId, options, procedure);
        }

        public void Call(IWampCaller caller, long requestId, TMessage options, string procedure, TMessage[] arguments)
        {
            mDealer.Call(caller, requestId, options, procedure, arguments);
        }

        public void Call(IWampCaller caller, long requestId, TMessage options, string procedure, TMessage[] arguments,
                         TMessage argumentsKeywords)
        {
            mDealer.Call(caller, requestId, options, procedure, arguments, argumentsKeywords);
        }

        public void Cancel(IWampCaller caller, long requestId, TMessage options)
        {
            mDealer.Cancel(caller, requestId, options);
        }

        public void Yield(IWampCallee callee, long requestId, TMessage options)
        {
            mDealer.Yield(callee, requestId, options);
        }

        public void Yield(IWampCallee callee, long requestId, TMessage options, TMessage[] arguments)
        {
            mDealer.Yield(callee, requestId, options, arguments);
        }

        public void Yield(IWampCallee callee, long requestId, TMessage options, TMessage[] arguments, TMessage argumentsKeywords)
        {
            mDealer.Yield(callee, requestId, options, arguments, argumentsKeywords);
        }

        public void Error(IWampClient client, int reqestType, long requestId, TMessage details, string error)
        {
            mDealer.Error(client, reqestType, requestId, details, error);
        }

        public void Error(IWampClient client, int reqestType, long requestId, TMessage details, string error, TMessage[] arguments)
        {
            mDealer.Error(client, reqestType, requestId, details, error, arguments);
        }

        public void Error(IWampClient client, int reqestType, long requestId, TMessage details, string error, TMessage[] arguments,
                          TMessage argumentsKeywords)
        {
            mDealer.Error(client, reqestType, requestId, details, error, arguments, argumentsKeywords);
        }

        public void Hello(IWampSessionClient client, string realm, TMessage details)
        {
            mSession.Hello(client, realm, details);
        }

        public void Authenticate(IWampSessionClient client, string signature, TMessage extra)
        {
            mSession.Authenticate(client, signature, extra);
        }

        public void Welcome(IWampSessionClient client, long session, TMessage details)
        {
            mSession.Welcome(client, session, details);
        }

        public void Goodbye(IWampSessionClient client, string reason, TMessage details)
        {
            mSession.Goodbye(client, reason, details);
        }

        public void Heartbeat(IWampSessionClient client, int incomingSeq, int outgoingSeq)
        {
            mSession.Heartbeat(client, incomingSeq, outgoingSeq);
        }

        public void Heartbeat(IWampSessionClient client, int incomingSeq, int outgoingSeq, string discard)
        {
            mSession.Heartbeat(client, incomingSeq, outgoingSeq, discard);
        }

        public void OnNewClient(IWampClient client)
        {
            mSession.OnNewClient(client);
        }

        public void Missing(IWampClient client, WampMessage<TMessage> rawMessage)
        {
        }
    }
}