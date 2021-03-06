    public class CarsController : Controller
    {
        private readonly ICommandHandler<RentCarCommand> rentCarHandler;
        public CarsController(ICommandHandler<RentCarCommand> rentCarHandler) {
            this.rentCarHandler = rentCarHandler;
        }
        public ActionResult Index(int carId, int userId) {
            if (this.ModelState.IsValid) {
                this.rentCarHandler.Handle(new RentCarCommand { CarId = carId, UserId = userId });
            }
            // etc.
        }
    }
