const BASE_URL = "http://localhost:3030/jsonstore/grocery/";
const productInputElement = document.getElementById("product");
const countInputElement = document.getElementById("count");
const priceInputElement = document.getElementById("price");
const addProductBtn = document.getElementById("add-product");
const updateProductBtn = document.getElementById("update-product");
const loadProductsBtn = document.getElementById("load-product");
const tbodyElement = document.getElementById("tbody");

let currentUpdateId = "";

loadProductsBtn.addEventListener("click", loadAllProducts);
addProductBtn.addEventListener("click", addProduct);
updateProductBtn.addEventListener("click", updateProduct);

async function loadAllProducts(e) {
    e.preventDefault();

    const response = await fetch(BASE_URL);
    let data = await response.json();
    data = Object.values(data);

    tbodyElement.innerHTML = "";
    for (const { product, count, price, _id } of data) {
        const trElement = createEl("tr", tbodyElement, "", "", _id);
        createEl("td", trElement, "name", product);
        createEl("td", trElement, "count-product", count);
        createEl("td", trElement, "product-price", price);

        const tdButtons = createEl("td", trElement, "btn");
        const updateBtn = createEl("button", tdButtons, "update", "Update");
        const deleteBtn = createEl("button", tdButtons, "delete", "Delete");

        updateBtn.addEventListener("click", tableUpdateProduct);
        deleteBtn.addEventListener("click", tableDeleteProduct);
    }
}

async function addProduct(e) {
    e.preventDefault();

    const product = productInputElement.value;
    const count = countInputElement.value;
    const price = priceInputElement.value;

    if (product != "" && count != "" && price != "") {
        const httpHeaders = {
            method: "POST",
            body: JSON.stringify({ product, count, price }),
        };

        await fetch(BASE_URL, httpHeaders);
        loadAllProducts(e);

        productInputElement.value = "";
        countInputElement.value = "";
        priceInputElement.value = "";
    }
}

async function updateProduct(e) {
    const product = productInputElement.value;
    const count = countInputElement.value;
    const price = priceInputElement.value;
    const httpHeaders = {
        method: "PATCH",
        body: JSON.stringify({ product, count, price }),
    };

    await fetch(`${BASE_URL}${currentUpdateId}`, httpHeaders);
    loadAllProducts(e);

    addProductBtn.disabled = false;
    updateProductBtn.disabled = true;
}

async function tableDeleteProduct(e) {
    const currentId = this.parentNode.parentNode.id;

    if (currentId != "") {
        const httpHeaders = { method: "DELETE" };
        await fetch(`${BASE_URL}${currentId}`, httpHeaders);
        loadAllProducts(e);
    }
}

function tableUpdateProduct() {
    const parentElement = this.parentNode.parentNode;
    currentUpdateId = parentElement.id;

    addProductBtn.disabled = true;
    updateProductBtn.disabled = false;

    const product = parentElement.querySelector(".name").textContent;
    const count = parentElement.querySelector(".count-product").textContent;
    const price = parentElement.querySelector(".product-price").textContent;

    productInputElement.value = product;
    countInputElement.value = count;
    priceInputElement.value = price;
}

function createEl(
    elementType,
    elementParent,
    elementClass,
    elementContent,
    elementId
) {
    const htmlElement = document.createElement(elementType);
    if (elementClass) htmlElement.classList.add(elementClass);
    if (elementContent) htmlElement.textContent = elementContent;
    if (elementId) htmlElement.id = elementId;

    elementParent.appendChild(htmlElement);
    return htmlElement;
}
