// const Sayilar =[2,3,4];
// yüksek işlevselli fonkdsiyonlar içinde parametre olarak da fonsikdyon kullanabilirzi.
const GirlPowerToplami =(x) =>
{
    return x + (x/3) +3;
}
const GirlPower =(arr , sum) =>
{
    return arr.map(x=> sum(x));
}
exports.modules 
{
    GirlPowerToplami
}
console.log(GirlPower ([1,2,3],GirlPowerToplami));
