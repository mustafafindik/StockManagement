/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { VatratesComponent } from './vatrates.component';

describe('VatratesComponent', () => {
  let component: VatratesComponent;
  let fixture: ComponentFixture<VatratesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VatratesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VatratesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
