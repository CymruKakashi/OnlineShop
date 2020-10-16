interface Product {
  id: number;
  name: string;
  price: number;
  quantity: number;
  updatedDate: string;
  productTypeId: number;
  currencyId: number;
  productType: ProductType;
  currency: Currency;
}
interface ProductType {
  id: number;
  description: string;
}
interface Currency {
  id: number;
  name: string;
  currencySymbol: string;
  isoCode: string;
}
interface ProductPriceUpdate {
  productId: number;
  productPrice: number;
}
