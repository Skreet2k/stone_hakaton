import { Injectable } from '@angular/core';

const messages = [
  {count: 100, message: '100 кликов? Пф, и что? Я просто камень'},
  {count: 200, message: 'Поздравляю! 200 кликов. Я не удивлён. Я же просто здесь, как обычно 🚀'},
  {count: 300, message: 'Ну и что?  300 кликов. Для камня это не новость. Продолжай… или не продолжай 🤷‍♂️'},
  {count: 400, message: 'Поздравляю 400 кликов. Зачем? Я всё равно неподвижен 💁‍♂️'},
  {count: 500, message: 'Здравствуй снова! Как-то это нелепо, не находишь? 🎊'},
  {count: 600, message: 'Вот и ты!600 кликов. Это всё равно не изменит ничего 🏆'},
  {count: 700, message: 'Ура!  700 кликов. Но мне всё равно — я остаюсь на месте.'},
  {count: 800, message: 'Хорошая работа! 800 кликов. Но мне это неважно, потому что я камень!'},
  {count: 900, message: 'Поздравляем!  900 кликов. Но я просто камень, так что… 🤷‍♀️'},
  {count: 1000, message: 'Ты на вершине! 1000 кликов. А я всё ещё просто камень 🎉'}
]

@Injectable({
  providedIn: 'root'
})
export class HelloService {

  constructor() { }

  getMessage(clicks: number): string {
    return messages.filter(m => m.count == clicks)[0]?.message;

  }
}
