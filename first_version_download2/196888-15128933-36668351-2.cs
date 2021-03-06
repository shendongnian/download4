        [ServiceContract(Namespace=ServiceContractNamespaces.ServiceContractNamespace,
                     SessionMode=SessionMode.Required,
                     CallbackContract = typeof(ISupportTicketCallback))]
    public interface ISupportTicketService
    {
               [OperationContract]
               int CreateSupportTicket (SupportTicket supportTicket);
    }
    public interface ISupportTicketCallback
    {
            [OperationContract]
            void SupportTicketCreated(int supportTicketId);
    }
