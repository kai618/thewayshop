const productListKey = 'thewayshop-products';
const productListEl = document.getElementById('product-list');
const productList = [];

function addProduct(id, name, price, amount, imageURL) {
  const index = productList.findIndex(p => p.id === id);
  if (index === -1)
    productList.push({
      id: id,
      name: name,
      price: price,
      amount: amount,
      imageURL: imageURL
    })
  else productList[index].amount++;

  storeProductList();
  refreshProductList();
}

function removeProduct(id) {
  // 
  setSum();
}

function refreshProductList() {  
  if (productList.length) {
    let rows = '';
    for (let p of productList) {
      rows += `
        <li>
          <a href="#" class="photo">
            <img src="${p.imageURL}" class="cart-thumb" alt="" />
          </a>
          <h6>
            <a href="#">${p.name}</a>
          </h6>
          <p>${p.amount}x - <span class="price">$${p.price}</span></p>
        </li>
      `;
    }

    rows += `
      <li class="total">
        <a href="#" class="btn btn-default hvr-hover btn-cart">VIEW CART</a>
        <span class="float-right"><strong>Total</strong>: $${getSum()}</span>
      </li>
    `;

    productListEl.innerHTML = rows;
  } else {
    productListEl.innerHTML = `
      <p>Empty Cart</p>
    `;
  }
}

function getSum() {
  let sum = 0;
  productList.forEach(p => sum += p.price * p.amount);
  return sum;
}

function fetchProductList() {
  const jsonData = localStorage.getItem(productListKey);
  if (!jsonData) return [];

  productList.push(...JSON.parse(jsonData));
  refreshProductList();
}

function storeProductList() {
  if (productList.length === 0) return;
  localStorage.setItem(productListKey, JSON.stringify(productList));
}

fetchProductList();