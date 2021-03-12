import { Component, ComponentFactoryResolver, Type, ViewChild, ComponentRef, ViewRef} from '@angular/core';
// import { Router } from '@angular/router';

import { DynamicComponentService } from './common/DynamicDirectives/dynamic-component.service';
import { DynamicComponentDirective } from './common/DynamicDirectives/dynamic-component.directive';
// import { DynamicComponent } from './common/DynamicDirectives/dynamic-component';
import { IDynamicComponent } from './common/DynamicDirectives/dynamic-component.interface';

@Component({
    selector: 'app-maestro-app',
    templateUrl: './app.component.html',
    styles: [`
      .full-height {
        height: 100%;
        width: 100%;
      }
      kendo-splitter + kendo-splitter { margin: 20px 0 0; }
      h3 { font-size: 1.2em; padding: 10px; }
    ` ]
})

export class AppComponent {

  @ViewChild(DynamicComponentDirective, { static: true }) DynamicComponentHost: DynamicComponentDirective;


//  public selectedKeys: any[] = [''];
//  public selectedKeys1: any[] = [''];
  public selectedTabName: string = '';
  private currentPath: string;

  public treeNodes: any[] = [
    {
      menuName: 'Clients',
      path:'ClientList',
      subMenus: [
        { menuName: 'Wall Shelving', link:'11111' },
        { menuName: 'Floor Shelving', link: '22222' },
        { menuName: 'Kids Storage', link: '333333' }
      ]
    },
    {
      menuName: 'Purchases',
      path: 'PurchaseList',
      subMenus: [
        { menuName: 'Ceiling' },
        { menuName: 'Table' },
        { menuName: 'Floor' }
      ]
    },
    {
      menuName: 'Products',
      path: 'ProductList',
      subMenus: [
        { menuName: 'Ceiling' },
        { menuName: 'Table' },
        { menuName: 'Floor' }
      ]
    },
    {
      menuName: 'Sales',
      path: 'SaleList',
      subMenus: [
        { menuName: 'Ceiling' },
        { menuName: 'Table' },
        { menuName: 'Floor' }
      ]
    }

  ];

  public tabs: any[] = [];
  public componentRefs: ViewRef[] = [];

  public selectedTab: string = '';

  public trackBy(index: number, item: any): any {
    return item.text + ' aaaa';
  }

  public handleNodeClick(event:any): void {

    var tabindex = this.tabs.findIndex(element => element.menuName == event.item.dataItem.menuName);

    this.selectedTab = event.item.dataItem.menuName;

    if (tabindex == -1) {
      this.tabs.push(event.item.dataItem);
      this.loadDynamicComponent(-1, event.item.dataItem.path);
    }
    else {
      this.loadDynamicComponent(tabindex, event.item.dataItem.path);
    }

//    this.router.navigateByUrl(event.item.dataItem.path);

  }

  public onTabSelect(e) {
//    this.selectedTabName = JSON.stringify(e);
//    console.log(e);

    this.selectedTab = this.tabs[e.index].menuName;
//    this.router.navigateByUrl(this.tabs[e.index].path);
    this.loadDynamicComponent(e.index, this.tabs[e.index].path);
  }

  public onTabCloseClick(index) {

    this.selectedTabName = "dddd: " +  JSON.stringify(index);

//    var index = this.tabs.findIndex(element => element.menuName == this.selectedTab);

    this.tabs.splice(index, 1);
    this.destroyDynamicComponent(index); 

    var newIndex = index;

    if (this.tabs.length == 0)
    {
      this.selectedTab = '';
      // this.router.navigateByUrl('');
      // this.loadDynamicComponent(newIndex, );
      return;
    }
    else
    {
      if (index > 0) newIndex = index - 1;
      this.selectedTab = this.tabs[newIndex].menuName;
    }

//    this.router.navigateByUrl(this.tabs[newIndex].path);
    this.loadDynamicComponent(newIndex, this.tabs[newIndex].path);
  }

//  constructor(private router: Router) {
  constructor(
    private dynamicComponentService: DynamicComponentService,
    private componentFactoryResolver: ComponentFactoryResolver
  ) {

  }

  private loadDynamicComponent(index, path: string) {

    //    if (currentPath!==)
    this.selectedTabName = path + ' ' + index;

    var component = this.dynamicComponentService.getComponent(path);
    const componentFactory = this.componentFactoryResolver.resolveComponentFactory(component);

    const viewContainerRef = this.DynamicComponentHost.viewContainer;
    viewContainerRef.detach();

//    viewContainerRef.clear();
//    var componentRef;

    if (index >= 0) {
      this.selectedTabName = path + ' ' + index + ' retreived';
      viewContainerRef.insert(this.componentRefs[index]);
    }
    else {
      const componentRef = viewContainerRef.createComponent<IDynamicComponent>(componentFactory);
      componentRef.instance.inputParams = {};
      componentRef.instance.userContext = {};
      this.componentRefs.push(componentRef.hostView);
    }

  }

  private destroyDynamicComponent(index) {

    const viewContainerRef = this.DynamicComponentHost.viewContainer;
    viewContainerRef.remove(index);

  }

}
