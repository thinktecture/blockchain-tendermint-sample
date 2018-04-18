import { Component, ElementRef, Input, Renderer2 } from '@angular/core';
import JSONFormatter from 'json-formatter-js';

@Component({
  selector: 'app-pretty-json',
  template: '',
})
export class PrettyJsonComponent {
  private previousElement;

  constructor(private readonly elementRef: ElementRef, private readonly renderer: Renderer2) {
  }

  @Input()
  set result(value: Object) {
    if (!value) {
      return;
    }

    const formatter = new JSONFormatter(value);

    if (this.previousElement) {
      this.renderer.removeChild(this.elementRef.nativeElement, this.previousElement);
    }

    this.previousElement = formatter.render();
    this.renderer.appendChild(this.elementRef.nativeElement, this.previousElement);
    formatter.openAtDepth(2);
  }
}
