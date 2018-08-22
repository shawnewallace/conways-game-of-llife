//
//  ViewController.swift
//  CGol
//
//  Created by Shawn Wallace on 9/22/16.
//  Copyright © 2016 Shawn Wallace. All rights reserved.
//

import UIKit

class ViewController: UIViewController, UITextFieldDelegate {
  @IBOutlet weak var fillFactorLabel: UILabel!
  @IBOutlet weak var fillFactorSlider: UISlider!
  @IBOutlet weak var widthText: UITextField!
  @IBOutlet weak var heightText: UITextField!
  @IBOutlet weak var theWorld: WorldControl!

  override func viewDidLoad() {
    super.viewDidLoad()
    // Do any additional setup after loading the view, typically from a nib.
    fillFactorLabel.text = "\(getFillFactor())"
    
    let tap: UITapGestureRecognizer = UITapGestureRecognizer(target: self, action: #selector(dismissKeyboard))
    self.view.addGestureRecognizer(tap)
  }

  override func didReceiveMemoryWarning() {
    super.didReceiveMemoryWarning()
    // Dispose of any resources that can be recreated.
  }

  @IBAction func fillFactorChanged(_ sender: UISlider) {
    let currentValue = getFillFactor()
    print("Slider changing to \(currentValue) ?")
    fillFactorLabel.text = "\(currentValue)"
  }
  
  func getFillFactor() -> Float {
    return fillFactorSlider.value.roundTo(places:1)
  }
  
  func textFieldShouldReturn(_ textField: UITextField) -> Bool {
    textField.resignFirstResponder()
    return true
  }
  
  func textFieldDidEndEditing(_ textField: UITextField) {
    //mealNameLabel.text = textField.text
  }
  
  func dismissKeyboard() {
    //Causes the view (or one of its embedded text fields) to resign the first responder status.
    view.endEditing(true)
  }
  
  
  @IBAction func startGame(_ sender: UIButton) {
    dismissKeyboard()
    
    //theWorld = WorldControl(coder: nil)
    theWorld.width = Int(widthText.text!)!
    theWorld.height = Int(heightText.text!)!
    
    theWorld.redraw()
    theWorld.setNeedsDisplay()
  }
}

