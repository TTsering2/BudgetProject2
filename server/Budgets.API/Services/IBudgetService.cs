interface IBudgetService<T>{
    public IEnumerable<T> ListItems();
    public T AddItem(T data);
    public bool DeleteItem(T data);
    public T UpdateItem(T data);
    public T GetItemById(int id);

}