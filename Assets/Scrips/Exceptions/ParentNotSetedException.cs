namespace ZombieTestProject.Exceptions
{
    [System.Serializable]
    public class ParentNotSetedException : System.Exception
    {
        public ParentNotSetedException() { }
        public ParentNotSetedException(string message) : base(message) { }
        public ParentNotSetedException(string message, System.Exception inner) : base(message, inner) { }
        protected ParentNotSetedException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}