const productListKey = 'thewayshop-products';
const productListEl = document.getElementById('product-list');
const productList = [];

let cartURL = '#';

$(document).ready(function () {
  fetchProductList();
  setAmountUI();
});

function addProduct(id, name, price, amount, imageURL, productURL) {
  const index = productList.findIndex(p => p.id === id);
  if (index === -1)
    productList.push({
      id: id,
      name: name,
      price: price,
      amount: amount,
      imageURL: imageURL,
      productURL: productURL,
    })
  else productList[index].amount++;

  processDataUI();
}

function removeProduct(id) {
  const index = productList.findIndex(p => p.id === id);
  if (index !== -1) productList.splice(index, 1);
  processDataUI();
}


function setAmountUI() {
  let amount = 0;
  productList.forEach(p => amount += p.amount);

  const amountBadge = document.getElementById('cart-amount-badge');
  amountBadge.innerHTML = amount;
}

function processDataUI() {
  storeProductList();
  refreshProductList();
  setAmountUI();
}

function setCartURL(url) {
  cartURL = url;
  refreshProductList();
}

function refreshProductList() {
  if (productList.length > 0) {
    let rows = '';
    for (let p of productList) {
      rows += `
        <li class="d-flex">
          <div class="d-flex align-items-center">
            <img src="${p.imageURL}" class="cart-thumb" alt="" width="50px" style="object-fit:contain;"/>
          </div>
          <div class="p-1">
              <a href="${p.productURL}"><b>${p.name}</b></a>           
            <p>${p.amount}x - <span class="price">$${p.price}</span></p>
          </div>
        </li>
      `;
    }

    rows += `
      <li class="total">
        <a href="${cartURL}" class="btn btn-default hvr-hover btn-cart">VIEW CART</a>
        <span class="float-right"><strong>Total</strong>: $${getSum().toFixed(2)}</span>
      </li>
    `;

    productListEl.innerHTML = rows;
  } else {
    productListEl.innerHTML = `      
      <p class="text-center"><b>Empty Cart</b></p>    
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
  if (!jsonData) {
    refreshProductList();
    return;
  }

  productList.push(...JSON.parse(jsonData));
  refreshProductList();
}

function storeProductList() {
  if (productList.length === 0) return;
  localStorage.setItem(productListKey, JSON.stringify(productList));
}