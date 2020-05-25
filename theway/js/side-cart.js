const productListKey = 'thewayshop-products';
const productList = [];

fetchProductList();

function addProduct(id, name, price, amount) {
  const index = productList.findIndex(p => p.id === id);
  if (index === -1)
    productList.push({
      id: id,
      name: name,
      price: price,
      amount: amount,
    })
  else productList[index].amount++;

  storeProductList();
}

function fetchProductList() {
  const jsonData = localStorage.getItem(productListKey);
  if (!jsonData) return [];

  productList.push(...JSON.parse(jsonData));
  console.log(productList);
}

function storeProductList() {
  if (productList.length === 0) return;
  localStorage.setItem(productListKey, JSON.stringify(productList));
}

const cartItemModel = {
  id: 1,
  name: 'Apple',
  price: 10,
  amount: 5,
}