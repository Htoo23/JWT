using BookingSystem.BookingSystem.Application.Interfaces;
using BookingSystem.BookingSystem.Application.Models;
using BookingSystem.BookingSystem.Domain.Entities;
using BookingSystem.BookingSystem.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingSystem.BookingSystem.Application.Services
{
    public class PackageService : IPackageService
    {
        private readonly IPackageRepository _packageRepository;

        public PackageService(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }

        // Create a new package
        public async Task<Package> CreatePackageAsync(CreatePackageRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var package = new Package
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Duration = request.Duration,  // in days
                CreatedDate = DateTime.UtcNow
            };

            var createdPackage = await _packageRepository.AddAsync(package);
            return createdPackage;
        }

    
        public async Task<IEnumerable<Package>> GetAllPackagesAsync()
        {
            var packages = await _packageRepository.GetAllAsync();
            return packages;
        }

        
        public async Task<Package> GetPackageByIdAsync(Guid packageId)
        {
            var package = await _packageRepository.GetByIdAsync(packageId);
            if (package == null)
                throw new KeyNotFoundException("Package not found.");

            return package;
        }

        public async Task<Package> UpdatePackageAsync(Guid packageId, UpdatePackageRequest request)
        {
            var package = await _packageRepository.GetByIdAsync(packageId);
            if (package == null)
                throw new KeyNotFoundException("Package not found.");

            package.Name = request.Name ?? package.Name;
            package.Description = request.Description ?? package.Description;
            package.Price = request.Price ?? package.Price;
            package.Duration = request.Duration ?? package.Duration;

            package.ModifiedDate = DateTime.UtcNow;

            var updatedPackage = await _packageRepository.UpdateAsync(package);
            return updatedPackage;
        }

       
        public async Task<bool> DeletePackageAsync(Guid packageId)
        {
            var package = await _packageRepository.GetByIdAsync(packageId);
            if (package == null)
                throw new KeyNotFoundException("Package not found.");

            var isDeleted = await _packageRepository.DeleteAsync(packageId);
            return isDeleted;
        }
    }
}
