//const KopekBakımUtility = require('./KopekBakımUtility')
// import {KopegiTemizle} from "./KopekBakımUtility.js";
// import { name, helloNamed } from "./util.js";
const {KopegiTemizle , KopekBakimSaati} = require('./KopekBakımUtility')
const {Kopek} = require('./Kopek')
// KopekBakımUtility.KopegiTemizle();
// console.log(Kopek);
console.log(`
Köpek Adı ${Kopek.Name} \nKopek Boyu : ${Kopek.High} \nKopek Kg : ${Kopek.Kg}\nKopek Age:${Kopek.Age}\nKopek Kind : ${Kopek.Kind}  `)
console.log(`Kopek Bakım Saati : ${KopekBakimSaati}`)
KopegiTemizle();


