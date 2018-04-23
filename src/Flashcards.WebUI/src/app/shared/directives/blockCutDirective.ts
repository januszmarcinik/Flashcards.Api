import {Directive, HostListener} from '@angular/core';

@Directive({
  selector: '[appBlockCut]'
})
export class BlockCutDirective {
  constructor() {
  }

  @HostListener('cut', ['$event']) blockCut(e: KeyboardEvent) {
    if (e.target['tagName'].toLowerCase() === 'img') {
      e.preventDefault();
    }
  }
}
