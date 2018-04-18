import { animate, style, transition, trigger } from '@angular/animations';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  animations: [
    trigger('expandable', [
      transition(':enter', [
        style({ height: 0 }),
        animate('500ms', style({ height: '*' })),
      ]),
      transition(':leave', [
        style({ height: '*' }),
        animate('500ms', style({ height: 0 })),
      ]),
    ]),
  ],
})
export class CardComponent {
  @Input()
  title: string;

  isOpen: boolean;

  toggle() {
    this.isOpen = !this.isOpen;
  }
}
