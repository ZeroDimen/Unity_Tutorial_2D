public class WirelessEarPhone3 : WirelessEarPhone2
{
        
        public enum NoiseCancelType
        {
                Off,On,Around
        }
        public NoiseCancelType noiseCancelType;


        private void Start()
        {
                name = "AirPodPro2";
                price = 200f;
                releaseYear = 2017;
                batterySize = 150f;
        }
        public void SetNoiseCancelType(NoiseCancelType type)
        {
                noiseCancelType = type;
        }
        public override void NoiseCancelling()
        {
                SetNoiseCancelType(noiseCancelType);
                base.NoiseCancelling();
        }
}