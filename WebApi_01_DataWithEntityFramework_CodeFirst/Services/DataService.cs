using WebApi_01_DataWithEntityFramework_CodeFirst.Data;
using WebApi_01_DataWithEntityFramework_CodeFirst.Models;

namespace WebApi_01_DataWithEntityFramework_CodeFirst.Services
{
    public class DataService : IHostedService
    {
        PersonDbContext _ctx;

        public DataService(PersonDbContext personDbContext)
        {
            _ctx = personDbContext;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return Task.CompletedTask;

            Task task = Task.Run(() =>
            {
                Console.WriteLine("Starting Data Service...");
                InitializeDatabase();
            });
            return task;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Task task = Task.Run(() => Console.WriteLine("Stopping Data Service"));
            return task;
        }

        private void InitializeDatabase()
        {
            Console.WriteLine("DB Providername: " + _ctx.Database.ProviderName);

            if (_ctx.People.Any())
            {
                foreach (var p in _ctx.People)
                {
                    Console.WriteLine(p.Id + " --- " + p.Name + " --- " + p.Age + " --- " + p.Address);
                }
                return;
            }


            Person person;
            Random random = new Random();
            List<string> names = new List<string>() { "Boris Dodson", "Sean Pugh", "Echo Juarez", "Phillip Dorsey", "Magee Gonzales" };
            List<string> addresses = new List<string>() { "Ap #687-1852 At, Ave", "Ap #965-4535 Ornare, Rd.", "4793 Massa. St.", "6659 Diam Rd.", "617-7027 Fermentum Rd." };

            for (int i = 0; i < 20; i++)
            {
                person = new Person
                {
                    Name = names[random.Next(names.Count)],
                    Address = addresses[random.Next(addresses.Count)],
                    Age = random.Next(20, 80)
                };

                _ctx.Add(person);
                _ctx.SaveChanges();
            }

            var people = _ctx.People;
            foreach (var p in _ctx.People)
            {
                Console.WriteLine(p.Id + " --- " + p.Name + " --- " + p.Age + " --- " + p.Address);
            }
        }
    }
}

