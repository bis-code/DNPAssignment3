﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FileData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using Models;

namespace WebClient.Data
{
    public class FamilyWebService : IFamilyService
    {
        private readonly DatabaseContext _databaseContext;

        public FamilyWebService()
        {
            _databaseContext = new DatabaseContext();
        }

        public async Task<IList<Family>> GetAllFamiliesAsync()
        {
            Console.WriteLine("Get families");
            return await _databaseContext.Families.
                Include(f => f.Adults).
                Include(f => f.Children)
                .ThenInclude(c => c.Interests).
                Include(f => f.Children).
                ThenInclude(c => c.Pets).Include(f => f.Pets)
                .ToListAsync();
        }

        public async Task<Family> GetFamilyAsync(int id)
        {
            Console.WriteLine("Get family");
            return await _databaseContext.Families.Include(f => f.Adults).
            Include(f => f.Children)
            .ThenInclude(c => c.Interests).
            Include(f => f.Children).ThenInclude(c => c.Pets).
            Include(f => f.Pets)
            .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Family> AddFamilyAsync(Family family)
        {
            await _databaseContext.Families.AddAsync(family);
            Console.WriteLine("From server: " + family.HouseNumber + " photo: " + family.Photo);
            await _databaseContext.SaveChangesAsync();
            Console.WriteLine("Add");
            return family;
        }

        public async Task<Family> RemoveFamilyAsync(int familyId)
        {
            Family toRemove = _databaseContext.Families.First(f => f.Id == familyId);
            _databaseContext.Families.Remove(toRemove);
            await _databaseContext.SaveChangesAsync();
            Console.WriteLine("Remove");
            return toRemove;
        }

        public async Task UpdateAsync(Family family)
        {
            List<Adult> adults = new List<Adult>();

            // var familyStored = await _databaseContext.Families.Include(f => f.Adults).
            //     ThenInclude(a => a.JobTitle).Include(f => f.Children)
            //     .ThenInclude(c => c.Interests).
            //     Include(f => f.Children).ThenInclude(c => c.Pets).
            //     Include(f => f.Pets)
            //     .FirstOrDefaultAsync(f => f.Id == family.Id);
            //     Include(f => f.Adults).Include(f => f.Children).ThenInclude()

            _databaseContext.Families.Update(family);
            // await _databaseContext.SaveChangesAsync();
            //
            // List<Child> children = new List<Child>();
            // List<Interest> interests = new List<Interest>();
            //
            // foreach (var child in family.Children)
            // {
            //     children.Add(child);
            //     if (child.Interests.Count > 0)
            //     {
            //         foreach (var interest in child.Interests)
            //         {
            //             interests.Add(interest);
            //         }
            //         _databaseContext.Interests.UpdateRange(interests);
            //         await _databaseContext.SaveChangesAsync();
            //     }
            //     _databaseContext.Children.UpdateRange(children);
            //     await _databaseContext.SaveChangesAsync();
            // }
            _databaseContext.Entry(family).State = EntityState.Modified;
            await _databaseContext.SaveChangesAsync();
            Console.WriteLine("Update");
        }


        // public async Task<IList<Family>> GetFamiliesAsync()
        // {
        //     HttpResponseMessage response = await client.GetAsync(uri + "/families");
        //     if (!response.IsSuccessStatusCode)
        //     {
        //         throw new Exception("Error");
        //     }
        //
        //     string message = await response.Content.ReadAsStringAsync();
        //     List<Family> result = JsonSerializer.Deserialize<List<Family>>(message);
        //     return result;
        // }
        //
        // public async Task<Family> GetFamilyAsync(int IdFamily)
        // {
        //     HttpResponseMessage response = await client.GetAsync($"{uri}/family/{IdFamily}");
        //     if (!response.IsSuccessStatusCode)
        //     {
        //         throw new Exception("Error");
        //     }
        //
        //     string message = await response.Content.ReadAsStringAsync();
        //     Family result = JsonSerializer.Deserialize<Family>(message);
        //     return result;
        // }
        //
        // public async Task<Adult> GetAdultAsync(int IdFamily, int IdAdult)
        // {
        //     HttpResponseMessage response = await client.GetAsync($"{uri}/family/{IdFamily}/adults/{IdAdult}");
        //     if (!response.IsSuccessStatusCode)
        //     {
        //         throw new Exception("Error");
        //     }
        //
        //     string message = await response.Content.ReadAsStringAsync();
        //     Adult result = JsonSerializer.Deserialize<Adult>(message);
        //     return result;
        // }
        //
        // public async Task<Child> GetChildAsync(int IdFamily, int IdChild)
        // {
        //     HttpResponseMessage response = await client.GetAsync($"{uri}/family/{IdFamily}/Child/{IdChild}");
        //     if (!response.IsSuccessStatusCode)
        //     {
        //         throw new Exception("Error");
        //     }
        //
        //     string message = await response.Content.ReadAsStringAsync();
        //     Child result = JsonSerializer.Deserialize<Child>(message);
        //     return result;
        // }
        //
        // public async Task<Pet> GetPetAsync(int IdFamily, int IdPet)
        // {
        //     HttpResponseMessage response = await client.GetAsync($"{uri}/family/{IdFamily}/pet/{IdPet}");
        //     if (!response.IsSuccessStatusCode)
        //     {
        //         throw new Exception("Error");
        //     }
        //
        //     string message = await response.Content.ReadAsStringAsync();
        //     Pet result = JsonSerializer.Deserialize<Pet>(message);
        //     return result;
        // }
        //
        // public async Task AddAdultToFamilyAsync(Family family, Adult _newAdult)
        // {
        //     string adultAsJson = JsonSerializer.Serialize(_newAdult);
        //     HttpContent content = new StringContent(adultAsJson, Encoding.UTF8, "application/json");
        //     HttpResponseMessage response = await client.PostAsync($"{uri}/family/{family.Id}/adult/{_newAdult.Id}", content);
        //     if (!response.IsSuccessStatusCode)
        //     {
        //         throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
        //     }
        // }
        //
        // public async Task AddChildToFamilyAsync(Family family, Child _newChild)
        // {
        //     string childAsJson = JsonSerializer.Serialize(_newChild);
        //     HttpContent content = new StringContent(childAsJson, Encoding.UTF8, "application/json");
        //     HttpResponseMessage response = await client.PostAsync($"{uri}/family/{family.Id}/child/{_newChild.Id}", content);
        //     if (!response.IsSuccessStatusCode)
        //     {
        //         throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
        //     }
        // }
        //
        // public async Task AddFamilyAsync(Family family)
        // {
        //     string familyAsJson = JsonSerializer.Serialize(family);
        //     HttpContent content = new StringContent(familyAsJson, Encoding.UTF8, "application/json");
        //     HttpResponseMessage response = await client.PostAsync($"{uri}/family/{family.Id}", content);
        //     if (!response.IsSuccessStatusCode)
        //     {
        //         throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
        //     }
        // }
        //
        // public async Task AddInterestAsync(int IdFamily, Child child, Interest interest)
        // {
        //     string interestAsJson = JsonSerializer.Serialize(interest);
        //     HttpContent content = new StringContent(interestAsJson, Encoding.UTF8, "application/json");
        //     HttpResponseMessage response = await client.PostAsync($"{uri}/family/{IdFamily}/child/{child.Id}/interest/{interest.Type}", content);
        //     if (!response.IsSuccessStatusCode)
        //     {
        //         throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
        //     }
        // }
        //
        // public async Task AddPetForFamilyAsync(Family family, Child? child, Pet pet)
        // {
        //     string petAsJson = JsonSerializer.Serialize(pet);
        //     HttpContent content = new StringContent(petAsJson, Encoding.UTF8, "application/json");
        //     HttpResponseMessage response = await client.PostAsync($"{uri}/family/{family.Id}/child/{child.Id}/pet/{pet.Id}", content);
        //     if (!response.IsSuccessStatusCode)
        //     {
        //         throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
        //     }
        // }
        //
        // public async Task UpdateFamilyAsync(Family family)
        // {
        //     string familyAsJson = JsonSerializer.Serialize(family);
        //     HttpContent content = new StringContent(familyAsJson,
        //         Encoding.UTF8,
        //         "application/json");
        //     HttpResponseMessage response = await client.PatchAsync($"{uri}/families/{family.Id}", content);
        //     if (!response.IsSuccessStatusCode)
        //     {
        //         throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
        //     }
        // }
        //
        // public async Task UpdateAdultAsync(int familyId, Adult adult)
        // {
        //     string adultAsJson = JsonSerializer.Serialize(adult);
        //     HttpContent content = new StringContent(adultAsJson,
        //         Encoding.UTF8,
        //         "application/json");
        //     HttpResponseMessage response = await client.PatchAsync($"{uri}/families/{familyId}/adult/{adult.Id}", content);
        //     if (!response.IsSuccessStatusCode)
        //     {
        //         throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
        //     }
        // }
        //
        // public async Task UpdateChildAsync(int familyId, Child child)
        // {
        //     string childAsJson = JsonSerializer.Serialize(child);
        //     HttpContent content = new StringContent(childAsJson,
        //         Encoding.UTF8,
        //         "application/json");
        //     HttpResponseMessage response = await client.PatchAsync($"{uri}/families/{familyId}/child/{child.Id}", content);
        //     if (!response.IsSuccessStatusCode)
        //     {
        //         throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
        //     }
        // }
        //
        // public async Task UpdatePetAsync(int familyId, Pet pet)
        // {
        //     string petAsJson = JsonSerializer.Serialize(pet);
        //     HttpContent content = new StringContent(petAsJson,
        //         Encoding.UTF8,
        //         "application/json");
        //     HttpResponseMessage response = await client.PatchAsync($"{uri}/families/{familyId}/pet/{pet.Id}", content);
        //     if (!response.IsSuccessStatusCode)
        //     {
        //         throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
        //     }
        // }
        //
        // public async Task RemoveFamilyAsync(Family family)
        // {
        //     HttpResponseMessage response = await client.DeleteAsync($"{uri}/family/{family.Id}");
        //     if (!response.IsSuccessStatusCode)
        //     {
        //         throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
        //     }
        // }
        //
        // public async Task RemoveAdultAsync(int IdFamily, Adult adult)
        // {
        //     HttpResponseMessage response = await client.DeleteAsync($"{uri}/family/{IdFamily}/adult/{adult.Id}");
        //     if (!response.IsSuccessStatusCode)
        //     {
        //         throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
        //     }
        // }
        //
        // public async Task RemoveChildAsync(int IdFamily, Child child)
        // {
        //     HttpResponseMessage response = await client.DeleteAsync($"{uri}/family/{IdFamily}/child/{child.Id}");
        //     if (!response.IsSuccessStatusCode)
        //     {
        //         throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
        //     }
        // }
        //
        // public async Task RemovePetAsync(int IdFamily, Pet pet)
        // {
        //     HttpResponseMessage response = await client.DeleteAsync($"{uri}/family/{IdFamily}/pet/{pet.Id}");
        //     if (!response.IsSuccessStatusCode)
        //     {
        //         throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
        //     }
        // }
    }
}