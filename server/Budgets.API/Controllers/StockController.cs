using Microsoft.AspNetCore.Mvc;
using Budgets.Models;
using Budgets.Services;
using Budgets.Data;
using Budgets.DTOs;


namespace Budget.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StockController : ControllerBase {
    private readonly IStockServices _stockServices;

    public StockController(IStockServices stockServices){
        _stockServices = stockServices;
    }

    /// <summary>
    /// Get all Stocks for a given User.
    /// </summary>
    /// <param name="UserId">The ID of the User.</param>
    /// <returns>An ActionResult containing the list of Stocks.</returns>
    [HttpGet("user/{UserId}")]
    public ActionResult<IEnumerable<Stock>> GetAllStocksForUser(int UserId){
        try {
            IEnumerable<StockDTO> Stocks = _stockServices.GetAllStocksForUser(UserId);

            if(Stocks == null || !Stocks.Any()){
                return NotFound("No Stocks found for the given User.");
            }

            return Ok(Stocks);
        } 
        catch (Exception ex){
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving Stocks by author: {ex.Message}");
        }    
    }

    /// <summary>
    /// Get a Stock by Id.
    /// </summary>
    /// <param name="Id">The ID of the Stock.</param>
    /// <returns>An ActionResult containing the Stock.</returns>
    [HttpGet("{Id}")]
    public ActionResult<StockDTO> GetStockById(int Id) {
        try{
            Stock stock = _stockServices.GetStockById(Id);
            if(stock == null){
                return NotFound("Stock not found.");
            }
            return Ok(stock);
        }
        catch (Exception ex){
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving Stock by Id: {ex.Message}");
        }
    
    }



    /// <summary>
    /// Add a Stock.
    /// </summary>
    /// <param name="stock">The Stock object to be added.</param>
    /// <returns>An ActionResult containing the newly added Stock.</returns>
    [HttpPost]
    public async Task<ActionResult<StockCreateDTO>> AddStock([FromBody]StockCreateDTO stock)
    {
        try
        {
            if (stock == null)
            {
                return BadRequest("Stock is null.");
            }
            
            StockCreateDTO createdStock = await _stockServices.AddStock(stock);
            return createdStock;
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error adding Stock: {ex.Message}");
        }
    }


    /// <summary>
    /// Update a Stock.
    /// </summary>
    /// <param name="Id">The ID of the Stock to be updated.</param>
    /// <param name="stock">The updated Stock object.</param>
    /// <returns>An ActionResult containing the updated Stock.</returns>
    [HttpPatch("{Id}")]
    public ActionResult<StockUpdateDTO> UpdateStock(int stockId, StockUpdateDTO stock){
        try
        {
            Stock updatedStock = _stockServices.UpdateStock(stockId, stock);

             if (updatedStock == null){
                    return NotFound("The stock could not be updated.");
                }
            // Map Stock to StockUpdateDTO
            var updatedStockDTO = new StockUpdateDTO
            {
                CompanyName = updatedStock.CompanyName,
                Price = updatedStock.Price,
                Quantity = updatedStock.Quantity
            };

            return updatedStockDTO;
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating Stock: {ex.Message}");
        }
    }
        
        
    

    /// <summary>
    /// Delete a Stock.
    /// </summary>
    /// <param name="Id">The ID of the Stock to be deleted.</param>
    /// <returns>An ActionResult containing the deleted Stock.</returns>
    [HttpDelete("{Id}")]
    public ActionResult<Stock?> DeleteStock(int Id){
        try{
            Stock deletedStock = _stockServices.DeleteStock(Id);
            if(deletedStock == null){
                return NotFound("Stock not found.");
            }
            return deletedStock;
        }
        catch (Exception ex){
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting Stock: {ex.Message}");
        
        }
    }

}


