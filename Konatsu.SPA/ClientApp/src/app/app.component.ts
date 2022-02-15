import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { Habit } from './habit';

@Component({
  selector: 'app',
  templateUrl: './app.component.html',
  providers: [DataService]
})
export class AppComponent implements OnInit {

  habit: Habit = new Habit();   // изменяемый товар
  habits: Habit[];                // массив товаров
  tableMode: boolean = true;          // табличный режим

  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.loadHabits();    // загрузка данных при старте компонента  
  }
  // получаем данные через сервис
  loadHabits() {
    this.dataService.getHabits()
      .subscribe((data: Habit[]) => this.habits = data);
  }
  // сохранение данных
  save() {
    if (this.habit.id == null) {
      this.dataService.createHabit(this.habit)
        .subscribe((data: Habit) => this.habits.push(data));
    } else {
      this.dataService.updateHabit(this.habit)
        .subscribe(data => this.loadHabits());
    }
    this.cancel();
  }
  editProduct(h: Habit) {
    this.habit = h;
  }
  cancel() {
    this.habit = new Habit();
    this.tableMode = true;
  }
  delete(h: Habit) {
    this.dataService.deleteHabit(h.id)
      .subscribe(data => this.loadHabits());
  }
  add() {
    this.cancel();
    this.tableMode = false;
  }
}
