namespace SafeHaven.DAL.Entities
{
    /// <summary>
    /// Представляет договор страхования, заключенный между клиентом и страховой компанией.
    /// </summary>
    public class Contract : BaseEntity
    {
        /// <summary>
        /// Дата начала действия договора.
        /// </summary>
        public DateTime StartDate { get; private set; }
        
        /// <summary>
        /// Дата окончания действия договора.
        /// </summary>
        public DateTime EndDate { get; private set; }
        
        /// <summary>
        /// Страховая сумма, указанная в договоре.
        /// </summary>
        public decimal InsuranceAmount { get; private set; }
        
        /// <summary>
        /// Страховая премия, уплачиваемая клиентом.
        /// </summary>
        public decimal PremiumAmount { get; private set; }
        
        /// <summary>
        /// Статус договора (активен/неактивен).
        /// </summary>
        public bool ContractStatus { get; private set; }

        /// <summary>
        /// Клиент, заключивший данный договор.
        /// </summary>
        public Client Client { get; set; }
        
        /// <summary>
        /// Тип страхования, применяемый в данном договоре.
        /// </summary>
        public InsuranceType InsuranceType { get; set; }

        /// <summary>
        /// Коллекция страховых случаев, связанных с данным договором.
        /// Доступна только для чтения.
        /// </summary>
        public IReadOnlyCollection<InsuranceCase> InsuranceCases => insuranceCases.AsReadOnly();
        
        // Внутренний список для хранения страховых случаев.
        private readonly List<InsuranceCase> insuranceCases = new List<InsuranceCase>();

        /// <summary>
        /// Коллекция платежей по данному договору.
        /// Доступна только для чтения.
        /// </summary>
        public IReadOnlyCollection<Payment> Payments => payments.AsReadOnly();

        // Внутренний список для хранения платежей.
        private readonly List<Payment> payments = new List<Payment>();

        /// <summary>
        /// Создает новый экземпляр договора страхования.
        /// </summary>
        /// <param name="startDate">Дата начала действия договора.</param>
        /// <param name="endDate">Дата окончания действия договора.</param>
        /// <param name="insuranceAmount">Страховая сумма.</param>
        /// <param name="premiumAmount">Размер страховой премии.</param>
        /// <param name="contractStatus">Статус договора (активен или нет).</param>
        public Contract(DateTime startDate, DateTime endDate, decimal insuranceAmount, decimal premiumAmount, bool contractStatus)
        {
            StartDate = startDate;
            EndDate = endDate;
            InsuranceAmount = insuranceAmount;
            PremiumAmount = premiumAmount;
            ContractStatus = contractStatus;
        }
    }
}
