namespace ManyToManyCore
{
    public class EntidadIntermedia<TDependent, THolder, TIdDep, TIdHold> where TDependent : IBaseEntity<TIdDep> where THolder : IBaseEntity<TIdHold>
    {
        public TDependent Dependent { get; set; }
        public THolder Holder { get; set; }
        public TIdDep IdDependent { get; set; }
        public TIdHold IdHolder { get; set; }

        public EntidadIntermedia() { }

        public EntidadIntermedia(TDependent dependent, THolder holder)
        {
            Holder = holder;
            IdHolder = Holder.Id;
            Dependent = dependent;
            IdDependent = dependent.Id;
        }
    }
}