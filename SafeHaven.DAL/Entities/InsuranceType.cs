namespace SafeHaven.DAL.Entities
{
    /// <summary>
    /// Представляет тип страхования, определяющий характеристики и описание вида страховки.
    /// </summary>
    public class InsuranceType : BaseEntity
    {
        /// <summary>
        /// Название типа страхования.
        /// </summary>
        public string Name { get; private set; }
        
        /// <summary>
        /// Описание типа страхования.
        /// </summary>
        public string Description { get; private set; }
        
        /// <summary>
        /// Коллекция договоров, применяющих этот тип страхования.
        /// Доступна только для чтения.
        /// </summary>
        public IReadOnlyCollection<Contract> Contracts => contracts.AsReadOnly();
        
        // Внутренний список для хранения договоров, связанных с данным типом.
        public List<Contract> contracts = new List<Contract>();

        /// <summary>
        /// Создает новый экземпляр типа страхования.
        /// </summary>
        /// <param name="name">Название типа страхования.</param>
        /// <param name="description">Описание типа страхования.</param>
        public InsuranceType(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}